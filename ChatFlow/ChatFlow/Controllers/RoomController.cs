using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void AddRoom([FromBody] Room room)
        {
            this.roomLogic.AddRoom(room);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{idRoom}")]
        public void DeleteRoom(string idRoom)
        {
            this.roomLogic.DeleteRoom(idRoom);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IQueryable<Room> GetAllRoom()
        {
            return this.roomLogic.GetAllRoom();
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("{idRoom}")]
        public Room GetOneRoom(string idRoom)
        {
            return this.roomLogic.GetOneRoom(idRoom);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void UpdateRoom([FromBody] Room updatedRoom)
        {
            this.roomLogic.UpdateRoom(updatedRoom);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("alluser/{idRoom}")]
        public IEnumerable<User> GetOneRoomsAllUsers(string idRoom)
        {
            return this.RUlogic.GetOneRoomsAllUsers(idRoom);
        }

        [Authorize(Roles = ("Teacher, Student"))]
        [HttpPost("{idRoom}")]
        public void AddThreadToRoom([FromBody] Threads threadToAdd, string idRoom)
        {
            var userid = this.User.Claims.FirstOrDefault(claim => claim.Type == "userId").Value;
            this.roomLogic.AddThreadToRoom(threadToAdd, idRoom, userid);
        }
    }
}
