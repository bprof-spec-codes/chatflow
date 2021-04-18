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
        IReactionRepository reactionRepository;

        public ThreadsLogic(IThreadsRepository threadsRepository, IReactionRepository reactionRepository)
        {
            this.threadsRepository = threadsRepository;
            this.reactionRepository =  reactionRepository;
        }

        public void AddMessageToThread(Messages message, string threadid)
        {
            this.GetOneThread(threadid).Messages.Add(message);
            this.threadsRepository.Save();
        }

        public void AddThread(Threads threads)
        {
            this.threadsRepository.Add(threads);
        }

        public void DeleteThread(Threads threads)
        {
            this.threadsRepository.Delete(threads);
        }

        public IQueryable<Threads> GetAllThread()
        {
            return this.threadsRepository.GetAll();
        }

        public IQueryable<Threads> GetAllThreadFromRoom(string idRoom)
        {
            return this.threadsRepository.GetAll().Where(thread => thread.RoomID == idRoom);
        }

        public Threads GetOneThread(string idThreads)
        {
            return this.threadsRepository.GetOne(idThreads);
        }

        public void UpdateThread(Threads updatedThreads)
        {
            this.threadsRepository.Update(updatedThreads);
        }

        public IQueryable<Threads> GetAllPinnedThread(string idRoom)
        {
            return this.threadsRepository.GetAll().Where(thread => thread.RoomID == idRoom && thread.IsPinned == true);
        }

        public void PinThread(string idThreads)
        {
            Threads thread = GetOneThread(idThreads);
            if (GetAllPinnedThread(thread.RoomID).Count() < 3)
            {
                this.threadsRepository.GetOne(idThreads).IsPinned = true;
                this.threadsRepository.Save();
            }
            else
            {
                throw new Exception("You have no more pin!");
            }
        }

        public void DeletePinThread(string idThreads)
        {
            this.threadsRepository.GetOne(idThreads).IsPinned = false;
            this.threadsRepository.Save();
        }

        public void AddReactionToThread(string idThreads, Reaction reaction)
        {
            this.threadsRepository.GetOne(idThreads).Reactions.Add(reaction);
            this.threadsRepository.Save();
        }

        public void DeleteReactionFromThread(string idReaction)
        {
            this.reactionRepository.Delete(idReaction);
            this.threadsRepository.Save();
        }

        public void UpdateReactionOnThread(string idReaction, ReactionType type)
        {
            this.reactionRepository.Update(idReaction, type);
            this.threadsRepository.Save();
        }
    }
}
