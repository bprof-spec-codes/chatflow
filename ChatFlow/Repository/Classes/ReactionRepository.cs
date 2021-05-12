using Data;
using Models;
using Repository.Classes;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReactionRepository : CommonRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(ChatFlowContext context) : base(context)
        {
        }

        public override void Delete(string id)
        {
            Delete(GetOne(id));
        }

        public override Reaction GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.ReactionID == id);
        }

        public override void Update(Reaction updatedItem)
        {
            var reaction = this.GetOne(updatedItem.ReactionID);
            reaction.ReactionType = updatedItem.ReactionType;
            this.Save();
        }
    }
}
