using Agency.Models;
using AutoMapper;
using Agency.Helper;
using Agency.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Collections.Generic;

namespace Agency.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        private readonly AgencyContext _context = new AgencyContext();
        private readonly FirebaseService _firebaseService = new FirebaseService();
        private IWebHostEnvironment _webHostEnvironment;

        private string SaveFile(IFormFile file)
        {
            string uploadFileName = null;
            string filePath = null;
            if (file != null)
            {
                string uploadFoloder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uploadFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                filePath = Path.Combine(uploadFoloder, uploadFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return "~/images/"+uploadFileName;
        }

        public DomainToResponseProfile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            CreateMap<Address, AddressViewModel>()
                .ForMember // Adding CountryId to ViewModel
                (
                    dest => dest.CountryId,
                    opt => opt.MapFrom(src => src.City.CountryId)
                )
                .ForMember //Adding Cities of Selected Country
                (
                    dest => dest.Cities,
                    opt => opt.MapFrom(src => _context.City
                        .Where(x => x.CountryId == src.City.CountryId)
                        .Select(x => new SelectListItem
                        { Value = x.Id.ToString(), Text = x.Name })
                        .ToList())
                )
                .ForMember //Adding All Countries
                (
                    dest => dest.Countries,
                    opt => opt.MapFrom(src => _context.Country
                        .Select(x => new SelectListItem
                        { Value = x.Id.ToString(), Text = x.Name })
                        .ToList())
                );

            CreateMap<AddressViewModel, Address>();

            CreateMap<Room, RoomViewModel>();

            CreateMap<IFormFile, Picture>()
                .ForMember
                (
                    dest => dest.Url,
                    opt => opt.MapFrom(src => this.SaveFile(src))
                )
                .ForMember
                (
                    dest => dest.FileName,
                    opt => opt.MapFrom(src => src.FileName)

                );

            CreateMap<RoomViewModel, Room>()
                .ForMember(dest => dest.Pictures, opt => opt.Ignore())
                //Insert/Add new Pictures
                .AfterMap((src, dest, context) =>
                    {
                        if (dest.Pictures == null)
                            dest.Pictures = new List<Picture>();
                        dest.Pictures.AddRange(context.Mapper.Map<List<Picture>>(src.Files));
                    }
                ); 

            CreateMap<Flat, FlatForm>();
            CreateMap<FlatForm, Flat>()
                .ForMember(dest => dest.Room, opt => opt.Ignore());

            CreateMap<PersonDetail, PersonDetailViewModel>().ReverseMap();

            CreateMap<PersonDetail, RentPersonDetailViewModel>().ReverseMap();
            CreateMap<Rent, RentViewModel>()
                .ForMember
                (
                    dest => dest.MojIdentityUserId,
                    opt => opt.MapFrom(src => src.Client.MojIdentityUserId)
                )
                .ForMember
                (
                    dest => dest.FlatTitle,
                    opt => opt.MapFrom(src => src.Flat.Name)
                )
                .AfterMap((src, dest, context) =>
                {
                    dest.PersonDetails = context.Mapper
                        .Map<RentPersonDetailViewModel>
                        (
                            _context.PersonDetail
                                .Where(x => x.MojIdentityUserId == dest.MojIdentityUserId)
                                .FirstOrDefault()
                        );
                });

            CreateMap<Picture, PictureViewModel>().ReverseMap();
        }
    }
}
