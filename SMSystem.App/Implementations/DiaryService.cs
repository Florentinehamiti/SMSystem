using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class DiaryService:IDiaryService
    {
        private readonly IDiaryRepository _diaryRepository;

        public DiaryService(IDiaryRepository diaryRepository)
        {
            _diaryRepository = diaryRepository;
        }

        public void AddDiary(Diary diary)
        {
            _diaryRepository.Add(diary);
        }

        public IEnumerable<Diary> GetAllDiaries()
        {
            return _diaryRepository.GetAll();
        }

        public Diary GetById(int id)
        {
            return _diaryRepository.GetById(id);
        }

        public void Remove(Diary diary)
        {
            _diaryRepository.Remove(diary);
        }

        public void Update(Diary diary)
        {
            _diaryRepository.Update(diary);
        }
    }
}
