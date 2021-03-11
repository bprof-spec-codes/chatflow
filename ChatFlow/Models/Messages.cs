using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Messages
    {
        public string MessageID { get; set; }
        public string Content { get; set; }
        public string SenderID { get; set; }
        public DateTime TimeStamp { get; set; }
        //Type? Emoji class?
        public string Reactions { get; set; }
    }
}
