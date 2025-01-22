using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;

namespace SMSystem.App.Implementations
{
    public class SubjectsService:ISubjectsService
    {
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            this._subjectsRepository = subjectsRepository;
        }

        public void AddSubject(Subject subject)
        {
            subject.InsertedDate = DateTime.Now;
            _subjectsRepository.Add(subject);
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _subjectsRepository.GetAll();
        }

        public Subject GetById(int id)
        {
            return _subjectsRepository.GetById(id);
        }

        public void Update(Subject subject)
        {
            _subjectsRepository.Update(subject);
        }
        public void Remove(Subject subject)
        {
            _subjectsRepository.Remove(subject);
        }

    }
}
