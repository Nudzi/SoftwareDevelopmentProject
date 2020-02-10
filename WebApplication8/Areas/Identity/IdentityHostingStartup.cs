using System;
using Agency.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication8.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WebApplication8.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication8.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AgencyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MojIdentityContextConnection")));

                services.AddDefaultIdentity<MojIdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AgencyContext>();
            });
        }
    }
}