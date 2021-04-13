using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IThreadsLogic
    {
        void AddThread(Threads threads);
        void DeleteThread(Threads threads);
        IQueryable<Threads> GetAllThread();
        Threads GetOneThread(string idThreads);
        void UpdateThread(Threads updatedThreads);
    }
}
