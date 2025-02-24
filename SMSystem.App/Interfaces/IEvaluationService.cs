using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IEvaluationService
    {
        void AddEvaluation(Evaluation evaluation);
        IEnumerable<Evaluation> GetAllEvaluations();
        Evaluation GetById(int id);
        void Update(Evaluation evaluation);
        void Remove(Evaluation evaluation);
        IEnumerable<Evaluation> GetAllEvaluationsForDiary(int id);
        IEnumerable<Evaluation> GetAllEvaluationsForSubjectAndDiary(int subjectId, int diaryId);
        Evaluation GetEvaluationForStudentInSubject(int subjectId, int studentId);
        IEnumerable<Evaluation> GetEvaluationsAndSubjectsForStudentByStudentId(int id);
        Task<IEnumerable<Evaluation>> GetEvaluationsForLoggedStudentAsync(string studentEmail);

    }
}
