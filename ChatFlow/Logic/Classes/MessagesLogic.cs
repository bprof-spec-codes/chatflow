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

        public MessagesLogic(IMessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public void AddMessage(Messages messages)
        {
            messagesRepository.Add(messages);
        }

        public void DeleteMessage(Messages messages)
        {
            messagesRepository.Delete(messages);
        }

        public IQueryable<Messages> GetAllMessage()
        {
            return messagesRepository.GetAll();
        }

        public Messages GetOneMessage(string idMessages)
        {
            return messagesRepository.GetOne(idMessages);
        }

        public void UpdateMessage(Messages updatedMessages)
        {
            messagesRepository.Update(updatedMessages);
        }
    }
}
