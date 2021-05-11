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
    public class RoomUserLogic : IRoomUserLogic
    {
        IRoomUserRepository RUrepo;

        public RoomUserLogic(IRoomUserRepository _RUrepo)
        {
            this.RUrepo = _RUrepo;
        }

        public IEnumerable<User> GetOneRoomsAllUsers(string roomid)
        {
            return this.RUrepo.GetOneRoomsAllUsers(roomid);
        }

        public IEnumerable<Room> GetOneUsersAllRooms(string userid)
        {
            return this.RUrepo.GetOneUsersAllRooms(userid);
        }
    }
}
