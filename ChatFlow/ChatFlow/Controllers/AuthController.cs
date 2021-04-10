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
        IAuthLogic logic;
        public AuthController(IAuthLogic _logic)
        {
            this.logic = _logic;
        }

        [HttpPost]
        public async Task<string> AddUser([FromBody] User user)
        {
            return await this.logic.CreateUser(user);
        }

        [HttpGet("{userid}")]
        public async Task<User> GetUser(string userid)
        {
            return await this.logic.GetUser(userid);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return this.logic.GetAllUser();
        }

        [HttpDelete("{userid}")]
        public async Task DeleteUser(string userid)
        {
            await this.logic.DeleteUser(userid);
        }

        [HttpPut]
        public async Task UpdateUser([FromBody] User user)
        {
            await this.logic.UpdateUser(user);
        }

        [HttpPatch]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                return Ok(await this.logic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {

                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
