using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class ThreadsLogic : IThreadsLogic
    {
        ICommonRepository<Threads> threadsRepository;

        public ThreadsLogic(ICommonRepository<Threads> threadsRepository)
        {
            this.threadsRepository = threadsRepository;
        }

        public void AddThreads(Threads threads)
        {
            threadsRepository.Add(threads);
        }

        public void DeleteThreads(Threads threads)
        {
            threadsRepository.Delete(threads);
        }

        public IQueryable<Threads> GetAllThreads()
        {
            return threadsRepository.GetAll();
        }

        public Threads GetOneThreads(string idThreads)
        {
            return threadsRepository.GetOne(idThreads);
        }

        public void UpdateThreads(Threads updatedThreads)
        {
            threadsRepository.Update(updatedThreads);
        }
    }
}
