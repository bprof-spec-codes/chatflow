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
    public class RoomRepository : CommonRepository<Room>, IRoomRepository
    {
        public RoomRepository(ChatFlowContext context) : base(context)
        {
        }

        public override Room GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.RoomID == id);
        }

        public override void Update(Room updatedItem)
        {
            var room = this.GetOne(updatedItem.RoomID);
            room.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(room, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
