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
    public class MessagesLogic : IMessagesLogic
    {
        IMessagesRepository messagesRepository;
        IReactionRepository reactionRepository;

        public MessagesLogic(IMessagesRepository messagesRepository, IReactionRepository reactionRepository)
        {
            this.messagesRepository = messagesRepository;
            this.reactionRepository = reactionRepository;
        }

        public void AddMessage(Messages messages)
        {
            this.messagesRepository.Add(messages);
        }

        public void DeleteMessage(string idMessages)
        {
            this.messagesRepository.Delete(idMessages);
        }

        public IQueryable<Messages> GetAllMessage()
        {
            return this.messagesRepository.GetAll();
        }

        public Messages GetOneMessage(string idMessages)
        {
            return this.messagesRepository.GetOne(idMessages);
        }

        public void UpdateMessage(Messages updatedMessages)
        {
            this.messagesRepository.Update(updatedMessages);
        }

        public void AddReactionToMessage(string idMessages, Reaction reaction)
        {
            this.messagesRepository.GetOne(idMessages).Reactions.Add(reaction);
            this.messagesRepository.Save();
        }

        public void DeleteReactionFromMessage(string idReaction)
        {
            this.reactionRepository.Delete(idReaction);
            this.messagesRepository.Save();
        }

        public void UpdateReactionOnMessage(string idReaction, ReactionType type)
        {
            this.reactionRepository.Update(idReaction, type);
            this.messagesRepository.Save();
        }
    }
}
