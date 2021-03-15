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
        ICommonRepository<Messages> messagesRepository;

        public MessagesLogic(ICommonRepository<Messages> messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public void AddMessages(Messages messages)
        {
            messagesRepository.Add(messages);
        }

        public void DeleteMessages(Messages messages)
        {
            messagesRepository.Delete(messages);
        }

        public IQueryable<Messages> GetAllMessages()
        {
            return messagesRepository.GetAll();
        }

        public Messages GetOneMessages(string id)
        {
            return messagesRepository.GetOne(id);
        }

        public void UpdateMessages(Messages updatedItem)
        {
            messagesRepository.Update(updatedItem);
        }
    }
}
