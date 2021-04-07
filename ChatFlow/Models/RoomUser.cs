using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomUser
    {
        public string RoomID { get; set; }

        public virtual Room Room { get; set; }

        public string UserID { get; set; }

        public virtual User User { get; set; }
    }
}
