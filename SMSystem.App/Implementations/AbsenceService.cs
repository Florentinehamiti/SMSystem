using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class AbsenceService : IAbsenceService
    {
        private readonly IAbsenceRepository _absenceRepository;

        public AbsenceService(IAbsenceRepository absenceRepository)
        {
            _absenceRepository = absenceRepository;
        }
        public IEnumerable<Absence> GetAllAbsencesForSubjectAndDiary(int diaryId)
        {
            return _absenceRepository.GetAbsencesByDiaryId(diaryId);
        }

        public IEnumerable<Absence> GetAbsencesAndSubjectsForStudentByStudentId(int id)
        {
            return _absenceRepository.GetAbsencesAndSubjectsForStudentByStudentId(id);
        }

    }
}
