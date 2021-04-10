using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IRoomLogic
    {
        void AddRoom(Room room);
        void DeleteRoom(Room room);
        IQueryable<Room> GetAllRoom();
        Room GetOneRoom(string idRoom);
        void UpdateRoom(Room updatedRoom);

        void GenerateData();
    }
}
