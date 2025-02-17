using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class SchoolHourService:ISchoolHourService
    {
       private readonly ISchoolHourRepository _schoolHourRepository;
        public SchoolHourService(ISchoolHourRepository schoolHourRepository)
        {
            _schoolHourRepository = schoolHourRepository;
        }

        public void AddSchoolHour(SchoolHour schoolHour)
        {
            _schoolHourRepository.Add(schoolHour);
        }

        public IEnumerable<SchoolHour> GetAllSchoolHours()
        {
            return _schoolHourRepository.GetAll();
        }

        public SchoolHour GetById(int id)
        {
            return _schoolHourRepository.GetById(id);
        }

        public void Remove(SchoolHour schoolHour)
        {
            _schoolHourRepository.Remove(schoolHour);
        }

        public void Update(SchoolHour schoolHour)
        {
            _schoolHourRepository.Update(schoolHour);
        }
        public IEnumerable<SchoolHour> GetAllSchoolHoursByDiaryIdAndTeacherId(int diaryId, int teacherId)
        {
           return _schoolHourRepository.GetAllSchoolHoursByDiaryIdAndTeacherId(diaryId, teacherId);
        }
    }
}
