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
    public class TeacherRepository : CommonRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public override Teacher GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.UserID == id);
        }

        public override void Update(Teacher updatedItem)
        {
            var teacher = this.GetOne(updatedItem.UserID);
            teacher.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(teacher, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
