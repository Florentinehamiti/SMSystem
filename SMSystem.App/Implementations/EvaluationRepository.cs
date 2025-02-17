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
    public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository
    {
        private readonly ApplicationDbContext _context;
        public EvaluationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Evaluation> GetEvaluationsBySubjectIdAndDiaryId(int subjectId, int diaryId)
        {
            return _context.Evaluations.Where(x => x.SubjectId == subjectId && x.DiaryId == diaryId).ToList();
        }
    }
}

