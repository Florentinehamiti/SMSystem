using Microsoft.AspNetCore.Hosting;
using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository, ApplicationDbContext context)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetById(int id) 
        { 
            return _teacherRepository.GetById(id);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
        public void Remove(Teacher teacher)
        {
            _teacherRepository.Remove(teacher);
        }
    }
}
