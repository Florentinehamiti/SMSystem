using Microsoft.EntityFrameworkCore;
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

        public Evaluation GetEvaluationForStudentInSubject(int subjectId, int studentId)
        {
            return _context.Evaluations.Where(x => x.SubjectId == subjectId && x.StudentId == studentId).FirstOrDefault();
        }

        public IEnumerable<Evaluation> GetAllEvaluationsForDiary(int diaryId)
        {
            return _context.Evaluations.Where(x => x.DiaryId == diaryId).ToList();
        }

        public IEnumerable<Evaluation> GetEvaluationsAndSubjectsForStudentByStudentId(int id)
        {
            return _context.Evaluations
                .Where(x => x.StudentId == id)
                .Include(e => e.Subject)
                .Include(e => e.Student)
                .ToList();
        }

    }
}

