using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public abstract class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        protected ChatFlowContext context;

        public CommonRepository(ChatFlowContext context)
        {
            this.context = context;
        }

        public void Add(T item)
        {
            this.context.Set<T>().Add(item);
            this.context.SaveChanges();
        }

        public void Delete(T item)
        {
            this.context.Set<T>().Remove(item);
            this.context.SaveChanges();
        }

        public abstract void Delete(string id);

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public abstract T GetOne(string id);

        public void Save()
        {
            this.context.SaveChanges();
        }

        public abstract void Update(T updatedItem);
    }
}
