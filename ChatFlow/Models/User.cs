using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class User : IdentityUser
    {
        public User() : base() { }
        public User(string userName) : base(userName) { }

        [JsonIgnore]
        public virtual ICollection<RoomUser> RoomUsers { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
