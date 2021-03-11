using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    class Room
    {
        [Key]
        public string RoomID { get; set; }
        [StringLength(64)]
        public string RoomName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Threads> Threads { get; set; }

    }
}
