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
        IThreadsRepository threadsRepository;

        public ThreadsLogic(IThreadsRepository threadsRepository)
        {
            this.threadsRepository = threadsRepository;
        }

        public void AddMessageToThread(Messages message, string threadid)
        {
            this.GetOneThread(threadid).Messages.Add(message);
            this.threadsRepository.Save();
        }

        public void AddThread(Threads threads)
        {
            threadsRepository.Add(threads);
        }

        public void DeleteThread(Threads threads)
        {
            threadsRepository.Delete(threads);
        }

        public IQueryable<Threads> GetAllThread()
        {
            return threadsRepository.GetAll();
        }

        public Threads GetOneThread(string idThreads)
        {
            return threadsRepository.GetOne(idThreads);
        }

        public void UpdateThread(Threads updatedThreads)
        {
            threadsRepository.Update(updatedThreads);
        }
    }
}
