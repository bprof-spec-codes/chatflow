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
        // Students and teachers
        public ICollection<User> Users { get; set; }

    }
}
