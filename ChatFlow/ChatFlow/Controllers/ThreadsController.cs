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
    public class ThreadsController : ControllerBase
    {
        IThreadsLogic threadsLogic;
        IAuthLogic authLogic;

        public ThreadsController(IThreadsLogic threadsLogic, IAuthLogic authLogic)
        {
            this.threadsLogic = threadsLogic;
            this.authLogic = authLogic;
        }

        [HttpDelete("{idThreads}")]
        public void DeleteThread(string idThreads)
        {
            this.threadsLogic.DeleteThread(idThreads);
        }

        [HttpGet]
        public IQueryable<Threads> GetAllThread()
        {
            return this.threadsLogic.GetAllThread();
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("Room/{idRoom}")]
        public IQueryable<Threads> GetAllThreadFromRoom(string idRoom)
        {
            return this.threadsLogic.GetAllThreadFromRoom(idRoom);
        }

        [HttpGet("{idThreads}")]
        public Threads GetOneThread(string idThreads)
        {
            return this.threadsLogic.GetOneThread(idThreads);
        }

        [HttpPut]
        public void UpdateThread([FromBody] Threads updatedThreads)
        {
            this.threadsLogic.UpdateThread(updatedThreads);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("Pinned/{idRoom}")]
        public IQueryable<Threads> GetAllPinnedThread(string idRoom)
        {
            return this.threadsLogic.GetAllPinnedThread(idRoom);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("Pin/{idThreads}")]
        public string PinThread(string idThreads)
        {
            try
            {
                this.threadsLogic.PinThread(idThreads);
                return "SUCCESS";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("DeletePin/{idThreads}")]
        public void DeletePinThread(string idThreads)
        {
            this.threadsLogic.DeletePinThread(idThreads);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpPost("AddReaction/{idThreads}")]
        public void AddReactionToThread([FromBody] Reaction reaction, string idThreads)
        {
            var userid = this.User.Claims.FirstOrDefault(claim => claim.Type == "userId").Value;
            var user = this.authLogic.GetAllUser().FirstOrDefault(x => x.Id == userid);
            this.threadsLogic.AddReactionToThread(reaction, idThreads, user);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpDelete("DeleteReaction/{idThreads}")]
        public void DeleteReactionFromThread(string idThreads)
        {
            this.threadsLogic.DeleteReactionFromThread(idThreads);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpPut("UpdateReaction")]
        public void UpdateReactionOnThread([FromBody] Reaction updatedReaction)
        {
            this.threadsLogic.UpdateReactionOnThread(updatedReaction);
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("Reactions/{idThreads}")]
        public IQueryable<Reaction> GetAllReactionFromMessage(string idThreads)
        {
            return threadsLogic.GetAllReactionFromThread(idThreads);
        }
    }
}
