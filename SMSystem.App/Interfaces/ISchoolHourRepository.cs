using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ISchoolHourRepository : IRepository<SchoolHour>
    {
        IEnumerable<SchoolHour> GetAllSchoolHoursByDiaryIdAndTeacherId(int diaryId, int teacherId);
    }
}
