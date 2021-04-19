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
    public class ThreadsController : ControllerBase
    {
        IThreadsLogic threadsLogic;
        IRoomLogic roomLogic;

        public ThreadsController(IThreadsLogic threadsLogic, IRoomLogic roomLogic)
        {
            this.threadsLogic = threadsLogic;
            this.roomLogic = roomLogic;
        }

        [HttpPost("{roomid}")]
        public void AddThread([FromBody] Threads threads, string roomid)
        {
            this.roomLogic.AddThreadToRoom(threads, roomid);
        }

        [HttpDelete("{idThreads}")]
        public void DeleteThread(string idThreads)
        {
            this.threadsLogic.DeleteThread(idThreads);
        }

        //only for testing
        [HttpGet]
        public IQueryable<Threads> GetAllThread()
        {
            return this.threadsLogic.GetAllThread();
        }

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

        [HttpGet("Pinned/{idRoom}")]
        public IQueryable<Threads> GetAllPinnedThread(string idRoom)
        {
            return this.threadsLogic.GetAllPinnedThread(idRoom);
        }

        [HttpPut("Pin/{idThreads}")]
        public void PinThread(string idThreads)
        {
            this.threadsLogic.PinThread(idThreads);
        }

        [HttpPut("DeletePin/{idThreads}")]
        public void DeletePinThread(string idThreads)
        {
            this.threadsLogic.DeletePinThread(idThreads);
        }

        [HttpPost("AddReaction/{idThreads}/{reactionNumber}")]
        public void AddReactionToThread(string idThreads, int reactionNumber)
        {
            if (reactionNumber <= 3 && reactionNumber > 0)
            {
                ReactionType reactionType = (ReactionType)reactionNumber;
                Reaction reaction = new Reaction { ThreadID = idThreads, ReactionType = reactionType };
                this.threadsLogic.AddReactionToThread(idThreads, reaction);
            }
            else
            {
                throw new Exception("Invalid number!");
            }
        }

        [HttpDelete("DeleteReaction/{idThreads}")]
        public void DeleteReactionFromThread(string idThreads)
        {
            this.threadsLogic.DeleteReactionFromThread(idThreads);
        }

        [HttpPut("UpdateReaction/{idThreads}/{reactionNumber}")]
        public void UpdateReactionOnThread(string idThreads, int reactionNumber)
        {
            if (reactionNumber <= 3 && reactionNumber > 0)
            {
                ReactionType reactionType = (ReactionType)reactionNumber;
                this.threadsLogic.UpdateReactionOnThread(idThreads, reactionType);
            }
            else
            {
                throw new Exception("Invalid number!");
            }
        }
    }
}
