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
    public class StudentRepository : CommonRepository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public override Student GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.UserID == id);
        }

        public override void Update(Student updatedItem)
        {
            var student = this.GetOne(updatedItem.UserID);
            student.GetType().GetProperties().ToList().ForEach(property =>
            {
                property.SetValue(student, property.GetValue(updatedItem));
            });
            this.Save();
        }
    }
}
