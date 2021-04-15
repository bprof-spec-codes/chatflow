using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRoomUserLogic
    {
        IEnumerable<Room> GetOneUsersAllRooms(string userid);

        IEnumerable<User> GetOneRoomsAllUsers(string roomid);
    }
}
