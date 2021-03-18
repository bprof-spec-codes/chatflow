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
    public class RoomLogic : IRoomLogic
    {
        IRoomRepository roomRepository;

        public RoomLogic(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public void AddRoom(Room room)
        {
            roomRepository.Add(room);
        }

        public void DeleteRoom(Room room)
        {
            roomRepository.Delete(room);
        }

        public IQueryable<Room> GetAllRoom()
        {
            return roomRepository.GetAll();
        }

        public Room GetOneRoom(string idRoom)
        {
            return roomRepository.GetOne(idRoom);
        }

        public void UpdateRoom(Room updatedRoom)
        {
            roomRepository.Update(updatedRoom);
        }
    }
}
