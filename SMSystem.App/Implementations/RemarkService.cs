using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class RemarkService : IRemarksService
    {
        private readonly IRemarksRepository _remarksRepository;
        public RemarkService(IRemarksRepository remarksRepository)
        {
            _remarksRepository = remarksRepository;
        }

        public async Task<IEnumerable<Remark>> GetRemarksAndSubjectsForStudentByStudentId(int id)
        {
           return await _remarksRepository.GetRemarksAndSubjectsForStudentByStudentId(id);
        }

        public void AddRemarkForStudentBySchoolHourAndDiaryId(Remark remark)
        {
            _remarksRepository.AddRemarkForStudentBySchoolHourAndDiaryId(remark);
        }

    }
}
