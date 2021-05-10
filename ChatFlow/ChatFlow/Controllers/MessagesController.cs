﻿using Logic.Classes;
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
    [Authorize(Roles = "Student, Teacher")]
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

        [HttpPost("{idThreads}")]
        public void AddMessage([FromBody] Messages messages, string idThreads)
        {
            var userid = this.User.Claims.FirstOrDefault(claim => claim.Type == "userId").Value;
            this.threadsLogic.AddMessageToThread(messages, idThreads, userid);
        }

        [HttpDelete("{idMessages}")]
        public void DeleteMessage(string idMessages)
        {
            this.messagesLogic.DeleteMessage(idMessages);
        }

        //[HttpGet]
        //public IQueryable<Messages> GetAllMessage()
        //{
        //    return messagesLogic.GetAllMessage();
        //}

        //[HttpGet("{idMessages}")]
        //public Messages GetOneMessage(string idMessages)
        //{
        //    return messagesLogic.GetOneMessage(idMessages);
        //}

        [HttpPut]
        public void UpdateMessage([FromBody] Messages updatedMessages)
        {
            messagesLogic.UpdateMessage(updatedMessages);
        }

        [HttpPost("AddReaction/{idMessages}")]
        public void AddReactionToMessage([FromBody] Reaction reaction, string idMessages)
        {
            this.messagesLogic.AddReactionToMessage(reaction, idMessages);
        }

        [HttpDelete("DeleteReaction/{idReaction}")]
        public void DeleteReactionFromMessage(string idReaction)
        {
            this.messagesLogic.DeleteReactionFromMessage(idReaction);
        }

        [HttpPut("UpdateReaction")]
        public void UpdateReactionOnMessage([FromBody] Reaction updatedReaction)
        {
            this.messagesLogic.UpdateReactionOnMessage(updatedReaction);
        }

        [HttpGet("Reactions/{idMessages}")]
        public IQueryable<Reaction> GetAllReactionFromMessage(string idMessages)
        {
            return messagesLogic.GetAllReactionFromMessage(idMessages);
        }

        [HttpGet("{idThreads}")]
        public IQueryable<Messages> GetEveryMessageFromThread(string idThreads)
        {
            return this.messagesLogic.GetAllMessagesOfAThread(idThreads);
        }
    }
}
