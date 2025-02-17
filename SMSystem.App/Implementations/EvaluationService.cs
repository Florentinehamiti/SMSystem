using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public void AddEvaluation(Evaluation evaluation)
        {
            _evaluationRepository.Add(evaluation);
        }

        public IEnumerable<Evaluation> GetAllEvaluations()
        {
            return _evaluationRepository.GetAll();
        }

        public IEnumerable<Evaluation> GetAllEvaluationsForDiary(int id)
        {
            return _evaluationRepository.GetAllEvaluationsForDiary(id);
        }

        public IEnumerable<Evaluation> GetAllEvaluationsForSubjectAndDiary(int subjectId, int diaryId)
        {
            return _evaluationRepository.GetEvaluationsBySubjectIdAndDiaryId(subjectId, diaryId);
        }

        public Evaluation GetById(int id)
        {
            return _evaluationRepository.GetById(id);
        }

        public Evaluation GetEvaluationForStudentInSubject(int subjectId, int studentId)
        {
            return _evaluationRepository.GetEvaluationForStudentInSubject(subjectId, studentId);
        }

        public void Remove(Evaluation evaluation)
        {
            _evaluationRepository.Remove(evaluation);
        }

        public void Update(Evaluation evaluation)
        {
            _evaluationRepository.Update(evaluation);
        }
    }
}
