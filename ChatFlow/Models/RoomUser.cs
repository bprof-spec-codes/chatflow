using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class RoomUser
    {
        [JsonIgnore]
        public string RoomID { get; set; }

        [JsonIgnore]
        public virtual Room Room { get; set; }

        [JsonIgnore]
        public string UserID { get; set; }

        public virtual User User { get; set; }
    }
}
