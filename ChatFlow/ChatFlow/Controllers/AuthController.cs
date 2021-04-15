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
    public class AuthController : ControllerBase
    {
        IAuthLogic authLogic;
        IRoomLogic roomLogic;
        IRoomUserLogic RUlogic;

        public AuthController(IAuthLogic _logic, IRoomLogic roomLogic, IRoomUserLogic _RUlogic)
        {
            this.authLogic = _logic;
            this.roomLogic = roomLogic;
            this.RUlogic = _RUlogic;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{userid}/{roomid}")]
        public void AddUserToRoom(string userid, string roomid)
        {
            this.roomLogic.AddUserToRoom(userid, roomid);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userid}/{roomid}")]
        public void RemoveUserFromRoom(string userid, string roomid)
        {
            this.roomLogic.RemoveUserFromRoom(userid, roomid);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return this.authLogic.GetAllUser();
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                return Ok(await this.authLogic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("allroom/{userid}")]
        public IEnumerable<Room> GetOneUsersAllRooms(string userid)
        {
            return this.RUlogic.GetOneUsersAllRooms(userid);
        }

        //only for testing
        //[HttpPost]
        //public async Task<string> AddUser([FromBody] User user)
        //{
        //    return await this.authLogic.CreateUser(user);
        //}

        //only for testing
        //[HttpGet("{userid}")]
        //public async Task<User> GetUser(string userid)
        //{
        //    return await this.authLogic.GetUser(userid);
        //}

        //only for testing
        //[HttpDelete("{userid}")]
        //public async Task DeleteUser(string userid)
        //{
        //    await this.authLogic.DeleteUser(userid);
        //}

        //only for testing
        //[HttpPut]
        //public async Task UpdateUser([FromBody] User user)
        //{
        //    await this.authLogic.UpdateUser(user);
        //}
    }
}
