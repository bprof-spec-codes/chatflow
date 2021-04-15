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

        [HttpDelete]
        public void DeleteThread([FromBody] Threads threads)
        {
            threadsLogic.DeleteThread(threads);
        }

        [HttpGet]
        public IQueryable<Threads> GetAllThread()
        {
            return threadsLogic.GetAllThread();
        }

        [HttpGet("{idThreads}")]
        public Threads GetOneThread(string idThreads)
        {
            return threadsLogic.GetOneThread(idThreads);
        }

        [HttpPut]
        public void UpdateThread([FromBody] Threads updatedThreads)
        {
            threadsLogic.UpdateThread(updatedThreads);
        }
    }
}
