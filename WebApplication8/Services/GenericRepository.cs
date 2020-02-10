using Agency.Interfaces;
using Agency.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Services
{
    public class GenericRepository<TEntry, TResult> : IGenericRepository<TEntry, TResult> where TEntry : class
    {
        private readonly AgencyContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<TEntry> _dbSet;

        public GenericRepository(AgencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntry>();
        }

        public async Task<IEnumerable<TResult>> GetAll()
        {
            return _mapper.Map<IEnumerable<TResult>>(await _dbSet.FindAsync());

        }

        public async Task<TResult> GetById(object id)
        {
            return _mapper.Map<TResult>(await _dbSet.FindAsync(id));
        }

        public void Insert(TEntry obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TEntry obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Update(TEntry entry, TResult obj)
        {
            if (entry == null)
            {
                entry = _mapper.Map<TEntry>(obj);
                _dbSet.Add(entry);
            }
            else
            {
                _mapper.Map<TResult, TEntry>(obj, entry);
                _dbSet.Attach(entry);
                _context.Entry(entry).State = EntityState.Modified;
            }
        }

        public void Delete(object id)
        {
            TEntry exists = _dbSet.Find(id);
            _dbSet.Remove(exists);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
