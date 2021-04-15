using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoomUserRepository
    {
        IEnumerable<Room> GetOneUsersAllRooms(string userid);

        IEnumerable<User> GetOneRoomsAllUsers(string roomid);
    }
}
