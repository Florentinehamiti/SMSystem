using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IRemarksService
    {
        void AddRemark(Remark remark);
        Task<IEnumerable<Remark>> GetRemarksAndSubjectsForStudentByStudentId(int diaryId);
        void AddRemarkForStudentBySchoolHourAndDiaryId(Remark remark);
    }
}
