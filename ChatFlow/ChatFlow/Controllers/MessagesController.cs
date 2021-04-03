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

        public MessagesController(IMessagesLogic messagesLogic)
        {
            this.messagesLogic = messagesLogic;
        }

        [HttpPost]
        public void AddMessage([FromBody] Messages messages)
        {
            messagesLogic.AddMessage(messages);
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
