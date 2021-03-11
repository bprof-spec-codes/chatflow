using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    // Renamed to threads, not to conflit with the built-in thread class
    class Threads
    {
        [Key]
        public string ThreadID { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public DateTime TimeStamp { get; set; }
        public string SenderID { get; set; }
        public bool IsPinned { get; set; }
    }
}
