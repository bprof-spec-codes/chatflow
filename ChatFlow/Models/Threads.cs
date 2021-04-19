using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    // Renamed to threads, not to conflit with the built-in thread class
    public class Threads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ThreadID { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }

        [NotMapped]
        public virtual ICollection<Reaction> Reactions { get; set; }

        public DateTime TimeStamp { get; set; }

        public string SenderID { get; set; }

        public bool IsPinned { get; set; }

        public string RoomID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Room Room { get; set; }

        public Threads()
        {
            this.Messages = new List<Messages>();
            this.Reactions = new List<Reaction>();
        }
    }
}
