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
        void DeleteMessage(Messages messages);
        IQueryable<Messages> GetAllMessage();
        Messages GetOneMessage(string idMessages);
        void UpdateMessage(Messages updatedMessages);
    }
}
