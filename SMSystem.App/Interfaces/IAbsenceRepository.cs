using SMSystem.App.Implementations;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IAbsenceRepository
    {
        IEnumerable<Absence> GetAbsencesByDiaryId(int diaryId);
        IEnumerable<Absence> GetAbsencesAndSubjectsForStudentByStudentId(int id);

    }
}
