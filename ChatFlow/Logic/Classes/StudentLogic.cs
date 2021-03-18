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
    public class StudentLogic : IStudentLogic
    {
        IStudentRepository studentRepository;

        public StudentLogic(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void AddStudent(Student student)
        {
            studentRepository.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            studentRepository.Delete(student);
        }

        public IQueryable<Student> GetAllStudent()
        {
            return studentRepository.GetAll();
        }

        public Student GetOneStudent(string idStudent)
        {
            return studentRepository.GetOne(idStudent);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            studentRepository.Update(updatedStudent);
        }
    }
}
