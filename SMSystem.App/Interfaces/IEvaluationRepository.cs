using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IEvaluationRepository: IRepository<Evaluation>
    {
        IEnumerable<Evaluation> GetEvaluationsBySubjectIdAndDiaryId(int subjectId, int diaryId);
        Evaluation GetEvaluationForStudentInSubject(int subjectId, int studentId);
        IEnumerable<Evaluation> GetAllEvaluationsForDiary(int diaryId);

    }
}
