using Data;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class RoomUserRepository : IRoomUserRepository
    {
        ChatFlowContext context;

        public RoomUserRepository(ChatFlowContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<User> GetOneRoomsAllUsers(string roomid)
        {
            return this.context.Set<RoomUser>().Where(ru => ru.RoomID == roomid).Select(ru => ru.User);
        }

        public IEnumerable<Room> GetOneUsersAllRooms(string userid)
        {
            return this.context.Set<RoomUser>().Where(ru => ru.UserID == userid).Select(ru => ru.Room);
        }
    }
}
