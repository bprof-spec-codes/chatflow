using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class TeacherLogic : ITeacherLogic
    {
        ICommonRepository<Teacher> teacherRepository;

        public TeacherLogic(ICommonRepository<Teacher> teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher)
        {
            teacherRepository.Add(teacher);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            teacherRepository.Delete(teacher);
        }

        public IQueryable<Teacher> GetAllTeacher()
        {
            return teacherRepository.GetAll();
        }

        public Teacher GetOneTeacher(string id)
        {
            return teacherRepository.GetOne(id);
        }

        public void UpdateTeacher(Teacher updatedItem)
        {
            teacherRepository.Update(updatedItem);
        }
    }
}
