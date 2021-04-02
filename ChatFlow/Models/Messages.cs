using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    // todo: emoji react (enum?)
    public class Messages
    {
        public string MessageID { get; set; }
        public string Content { get; set; }
        public string SenderID { get; set; }
        public DateTime TimeStamp { get; set; }
        public IList<char> Reactions { get; set; }

        public string ThreadID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Threads Threads { get; set; }
    }
}
