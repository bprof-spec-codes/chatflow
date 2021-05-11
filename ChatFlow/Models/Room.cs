using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RoomID { get; set; }

        [StringLength(64)]
        public string RoomName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RoomUser> RoomUsers { get; set; }
        // todo: user and role management

        public virtual ICollection<Threads> Threads { get; set; }

        public Room()
        {
            this.Threads = new List<Threads>();
            this.RoomUsers = new List<RoomUser>();
        }
    }
}
