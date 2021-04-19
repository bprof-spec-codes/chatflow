using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IMessagesLogic
    {
        void AddMessage(Messages messages);
        void DeleteMessage(string idMessages);
        IQueryable<Messages> GetAllMessage();
        Messages GetOneMessage(string idMessages);
        void UpdateMessage(Messages updatedMessages);
        void AddReactionToMessage(string idMessages, Reaction reaction);
        void DeleteReactionFromMessage(string idReaction);
        void UpdateReactionOnMessage(string idReaction, ReactionType type);
    }
}
