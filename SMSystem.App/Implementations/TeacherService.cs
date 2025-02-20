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

        public Teacher GetByEmail(string email)
        {
            return _teacherRepository.GetByEmail(email);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
        public void Remove(Teacher teacher)
        {
            _teacherRepository.Remove(teacher);
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsAndSubjectsByDiaryId(int diaryId)
        {
            return await _teacherRepository.GetEvaluationsAndSubjectsByDiaryId(diaryId);
        }

        public async Task<Diary?> GetDiaryIdForLoggedTeacherAsync(string teacherEmail)
        {
            return await _teacherRepository.GetDiaryIdByTeacherEmailAsync(teacherEmail);
        }
    }
}
