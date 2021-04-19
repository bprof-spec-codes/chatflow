using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IReactionRepository
    {
        void Add(Reaction reaction);
        void Delete(Reaction reaction);
        void Delete(string id);
        Reaction GetOne(string id);
        void Update(string id, ReactionType type);
    }
}
