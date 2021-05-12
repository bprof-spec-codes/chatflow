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
        void DeleteThread(string idThreads);
        IQueryable<Threads> GetAllThread();
        IQueryable<Threads> GetAllThreadFromRoom(string idRoom);
        Threads GetOneThread(string idThreads);
        void UpdateThread(Threads updatedThreads);
        void AddMessageToThread(Messages message, string idThread, User user);
        IQueryable<Threads> GetAllPinnedThread(string roomId);
        void PinThread(string idThreads);
        void DeletePinThread(string idThreads);
        void AddReactionToThread(Reaction reaction, string idThreads, User user);
        void DeleteReactionFromThread(string idReaction);
        void UpdateReactionOnThread(Reaction reaction);
        IQueryable<Reaction> GetAllReactionFromThread(string idThreads);
    }
}
