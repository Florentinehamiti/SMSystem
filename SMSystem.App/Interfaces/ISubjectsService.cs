using SMSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface ISubjectsService
    {
        void AddSubject(Subject subject);
        IEnumerable<Subject> GetAllSubjects();
        Subject GetById(int id);
        void Update(Subject subject);
        void Remove(Subject subject);
    }
}
