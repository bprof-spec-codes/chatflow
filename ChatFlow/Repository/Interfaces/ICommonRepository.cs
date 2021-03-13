using System;
using System.Linq;

namespace Repository.Interfaces
{
    // general repo interface: CRUD + save(for methods in Logic if needed)
    public interface ICommonRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetOne(string id);
        void Add(T item);
        void Update(T updatedItem);
        void Delete(T item);
        void Save();
    }
}
