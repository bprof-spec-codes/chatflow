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
    public class AuthController : ControllerBase
    {
        IAuthLogic authLogic;
        IRoomLogic roomLogic;

        public AuthController(IAuthLogic _logic, IRoomLogic roomLogic)
        {
            this.authLogic = _logic;
            this.roomLogic = roomLogic;
        }

        [HttpPost]
        public async Task<string> AddUser([FromBody] User user)
        {
            return await this.authLogic.CreateUser(user);
        }

        [HttpPost("{userid}/{roomid}")]
        public void AddUserToRoom(string userid, string roomid)
        {
            this.roomLogic.AddUserToRoom(userid, roomid);
        }

        [HttpDelete("{userid}/{roomid}")]
        public void RemoveUserFromRoom(string userid, string roomid)
        {
            this.roomLogic.RemoveUserFromRoom(userid, roomid);
        }

        [HttpGet("{userid}")]
        public async Task<User> GetUser(string userid)
        {
            return await this.authLogic.GetUser(userid);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return this.authLogic.GetAllUser();
        }

        [HttpDelete("{userid}")]
        public async Task DeleteUser(string userid)
        {
            await this.authLogic.DeleteUser(userid);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody] User user)
        {
            await this.authLogic.UpdateUser(user);
        }

        [HttpPatch]
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
    }
}
