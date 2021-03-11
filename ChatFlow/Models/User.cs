using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    class User
    {
        [Key]
        public string UserID { get; set; }
        [StringLength(64)]
        public string Username { get; set; }
        [StringLength(32)]
        public string Password { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
