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

        public void AddMessageToThread(Messages message, string threadid, User user)
        {
            message.SenderName = $"{user.FirstName} {user.LastName}";
            message.TimeStamp = DateTime.Now;
            this.GetOneThread(threadid).Messages.Add(message);
            this.threadsRepository.Save();
        }

        public void AddThread(Threads threads)
        {
            this.threadsRepository.Add(threads);
        }

        public void DeleteThread(string idThreads)
        {
            this.threadsRepository.Delete(idThreads);
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

        public void AddReactionToThread(Reaction reaction, string idThreads, User user)
        {
            reaction.SenderName = $"{user.FirstName} {user.LastName}";
            this.threadsRepository.GetOne(idThreads).Reactions.Add(reaction);
            this.threadsRepository.Save();
        }

        public void DeleteReactionFromThread(string idReaction)
        {
            this.reactionRepository.Delete(idReaction);
            this.threadsRepository.Save();
        }

        public void UpdateReactionOnThread(Reaction reaction)
        {
            this.reactionRepository.Update(reaction);
        }

        public IQueryable<Reaction> GetAllReactionFromThread(string idThreads)
        {
            return this.reactionRepository.GetAll().Where(reaction => reaction.ThreadID == idThreads);
        }
    }
}
