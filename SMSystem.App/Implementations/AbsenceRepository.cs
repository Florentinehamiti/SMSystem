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
    public class AbsenceRepository : Repository<Absence>, IAbsenceRepository
    {
        private readonly ApplicationDbContext _context;
        public AbsenceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Absence> GetAbsencesBySubjectIdAndDiaryId(int subjectId, int diaryId)
        {
            return _context.Absences.Where(x => x.SubjectId == subjectId && x.DiaryId == diaryId).ToList();
        }
    }
}
