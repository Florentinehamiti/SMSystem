using SMSystem.Models.Entities;

namespace SMSystem.App.Interfaces
{
    public interface ISchoolHourService
    {
        void AddSchoolHour(SchoolHour schoolHour);
        IEnumerable<SchoolHour> GetAllSchoolHours();
        SchoolHour GetById(int id);
        void Update(SchoolHour schoolHour);
        void Remove(SchoolHour schoolHour);
        IEnumerable<SchoolHour> GetAllSchoolHoursByDiaryIdAndTeacherId(int diaryId, int teacherId);
    }
}
