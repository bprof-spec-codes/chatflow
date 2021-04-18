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
    public class ReactionRepository : IReactionRepository
    {
        ChatFlowContext context;

        public ReactionRepository(ChatFlowContext context)
        {
            this.context = context;
        }

        public void Add(Reaction reaction)
        {
            this.context.Set<Reaction>().Add(reaction);
            this.context.SaveChanges();
        }

        public void Delete(Reaction reaction)
        {
            this.context.Set<Reaction>().Remove(reaction);
            this.context.SaveChanges();
        }

        public void Delete(string id)
        {
            Delete(GetOne(id));

        }

        public Reaction GetOne(string id)
        {
            return this.context.Set<Reaction>().SingleOrDefault(x => x.ReactionID == id);
        }

        public void Update(string id, ReactionType type)
        {
            Reaction reaction = this.context.Set<Reaction>().SingleOrDefault(x => x.ReactionID == id);
            reaction.ReactionType = type;

            this.context.SaveChanges();
        }
    }
}
