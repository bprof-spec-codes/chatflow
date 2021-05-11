using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class ThreadsRepository : CommonRepository<Threads>, IThreadsRepository
    {
        public ThreadsRepository(ChatFlowContext context) : base(context)
        {
        }

        public override Threads GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.ThreadID == id);
        }

        public override void Delete(string id)
        {
            Delete(GetOne(id));
        }

        public override void Update(Threads updatedItem)
        {
            var thread = this.GetOne(updatedItem.ThreadID);
            thread.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(thread, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
