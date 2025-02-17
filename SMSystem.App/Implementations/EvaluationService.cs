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

        public IEnumerable<Evaluation> GetAllEvaluationsForSubjectAndDiary(int subjectId, int diaryId)
        {
            return _evaluationRepository.GetEvaluationsBySubjectIdAndDiaryId(subjectId, diaryId);
        }
    }
}
