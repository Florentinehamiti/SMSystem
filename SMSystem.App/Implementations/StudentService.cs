using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void Remove(Student student)
        {
            _studentRepository.Update(student);
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
