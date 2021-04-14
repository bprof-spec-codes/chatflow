using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatFlow.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RoomController : ControllerBase
    {
        IRoomLogic roomLogic;
        IRoomUserLogic RUlogic;

        public RoomController(IRoomLogic roomLogic, IRoomUserLogic _RUlogic)
        {
            this.roomLogic = roomLogic;
            this.RUlogic = _RUlogic;
        }

        [HttpPost]
        public void AddRoom([FromBody] Room room)
        {
            roomLogic.AddRoom(room);
        }

        [HttpDelete]
        public void DeleteRoom([FromBody] Room room)
        {
            roomLogic.DeleteRoom(room);
        }

        [HttpGet]
        public IQueryable<Room> GetAllRoom()
        {
            return roomLogic.GetAllRoom();
        }

        [HttpGet("{idRoom}")]
        public Room GetOneRoom(string idRoom)
        {
            return roomLogic.GetOneRoom(idRoom);
        }

        [HttpPut]
        public void UpdateRoom([FromBody] Room updatedRoom)
        {
            roomLogic.UpdateRoom(updatedRoom);
        }

        [HttpGet("alluser/{roomid}")]
        public IEnumerable<User> GetOneRoomsAllUsers(string roomid)
        {
            return this.RUlogic.GetOneRoomsAllUsers(roomid);
        }
    }
}
