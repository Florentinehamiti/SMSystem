using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IDiaryService
    {
        void AddDiary(Diary diary);
        IEnumerable<Diary> GetAllDiaries();
        Diary GetById(int id);
        void Update(Diary diary);
        void Remove(Diary diary);
    }
}
