using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class MessagesRepository : CommonRepository<Messages>, IMessagesRepository
    {
        public MessagesRepository(ChatFlowContext context) : base(context)
        {
        }

        public override Messages GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.MessageID == id);
        }

        public override void Delete(string id)
        {
            Delete(GetOne(id));
        }

        public override void Update(Messages updatedItem)
        {
            var message = this.GetOne(updatedItem.MessageID);
            message.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(message, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
