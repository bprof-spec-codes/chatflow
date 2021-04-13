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
    public class MessagesController : ControllerBase
    {
        IMessagesLogic messagesLogic;
        IThreadsLogic threadsLogic;

        public MessagesController(IMessagesLogic messagesLogic, IThreadsLogic threadsLogic)
        {
            this.messagesLogic = messagesLogic;
            this.threadsLogic = threadsLogic;
        }

        [HttpPost("{threadid}")]
        public void AddMessage([FromBody] Messages messages, string threadid)
        {
            this.threadsLogic.AddMessageToThread(messages, threadid);
        }

        [HttpDelete]
        public void DeleteMessage([FromBody] Messages messages)
        {
            messagesLogic.DeleteMessage(messages);
        }

        [HttpGet]
        public IQueryable<Messages> GetAllMessage()
        {
            return messagesLogic.GetAllMessage();
        }

        [HttpGet("{idMessages}")]
        public Messages GetOneMessage(string idMessages)
        {
            return messagesLogic.GetOneMessage(idMessages);
        }

        [HttpPut]
        public void UpdateMessage([FromBody] Messages updatedMessages)
        {
            messagesLogic.UpdateMessage(updatedMessages);
        }
    }
}
