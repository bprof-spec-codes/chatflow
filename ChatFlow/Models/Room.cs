using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RoomID { get; set; }

        [StringLength(64)]
        public string RoomName { get; set; }

        // public ICollection<Student> Students { get; set; }
        // public ICollection<Teacher> Teachers { get; set; }
        // todo: user and role management

        public virtual ICollection<Threads> Threads { get; set; }

        public Room()
        {
            this.Threads = new List<Threads>();
        }
    }
}
