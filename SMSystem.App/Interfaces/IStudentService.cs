using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetById(int id);
        void Update(Student student);
        void Remove(Student student);
        IEnumerable<Student> GetAllStudentsForDiary(int id);

    }
}
