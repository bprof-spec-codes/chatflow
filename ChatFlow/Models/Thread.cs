using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    class Thread
    {
        [Key]
        public string ThreadID { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public DateTime TimeStamp { get; set; }
        public string SenderID { get; set; }
    }
}
