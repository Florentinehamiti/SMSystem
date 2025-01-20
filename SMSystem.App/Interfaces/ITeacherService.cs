using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher teacher);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetById(int id);
        void Update(Teacher teacher);

        void Remove(Teacher teacher);
    }
}
