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

        [HttpDelete("{idMessages}")]
        public void DeleteMessage(string idMessages)
        {
            this.messagesLogic.DeleteMessage(idMessages);
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

        [HttpPost("AddReaction/{idMessages}/{reactionNumber}")]
        public void AddReactionToMessage(string idMessages, int reactionNumber)
        {
            ReactionType reactionType = (ReactionType)reactionNumber;
            Reaction reaction = new Reaction();
            reaction.MessageID = idMessages;
            reaction.ReactionType = reactionType;
            
            this.messagesLogic.AddReactionToMessage(idMessages, reaction);
        }

        [HttpDelete("DeleteReaction/{idReaction}")]
        public void DeleteReactionFromMessage(string idReaction)
        {
            this.messagesLogic.DeleteReactionFromMessage(idReaction);
        }

        [HttpPut("UpdateReaction/{idReaction}/{reactionNumber}")]
        public void UpdateReactionOnMessage(string idReaction, int reactionNumber)
        {
            if (reactionNumber <= 3 && reactionNumber > 0)
            {
                ReactionType reactionType = (ReactionType)reactionNumber;
                this.messagesLogic.UpdateReactionOnMessage(idReaction, reactionType);
            }
            else
            {
                throw new Exception("Invalid number!");
            }
        }
    }
}
