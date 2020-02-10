using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Interfaces
{
    public interface IGenericRepository<TEntry, TResult> where TEntry: class
    {
        public Task<IEnumerable<TResult>> GetAll();
        public Task<TResult> GetById(object id);
        public void Insert(TEntry obj);
        public void Update(TEntry obj);

        public void Update(TEntry entry, TResult obj);

        public void Delete(object id);
        public void Save();
    }
}
