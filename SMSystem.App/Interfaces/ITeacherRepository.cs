using SMSystem.App.Implementations;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ITeacherRepository: IRepository<Teacher>
    {
        Teacher GetByEmail(string email);
        Task<IEnumerable<Evaluation>> GetEvaluationsAndSubjectsByDiaryId(int diaryId);
        Task<Diary?> GetDiaryIdByTeacherEmailAsync(string teacherEmail);

    }
}
