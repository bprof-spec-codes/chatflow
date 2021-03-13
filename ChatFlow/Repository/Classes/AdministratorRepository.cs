using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class AdministratorRepository : CommonRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(DbContext context) : base(context)
        {
        }

        public override Administrator GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.UserID == id);
        }

        public override void Update(Administrator updatedItem)
        {
            var user = this.GetOne(updatedItem.UserID);
            // sets all property values of user to updatedItems property values
            user.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(user, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
