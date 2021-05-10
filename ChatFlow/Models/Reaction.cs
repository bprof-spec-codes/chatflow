using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public enum ReactionType
    {
        Smile = 1,
        GreenTick = 2,
        RedHeart = 3
    }

    public class Reaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ReactionID { get; set; }
        public ReactionType ReactionType { get; set; }
        public string SenderName { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }
        public string MessageID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Messages Message { get; set; }
        public string ThreadID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Threads Thread { get; set; }
    }
}
