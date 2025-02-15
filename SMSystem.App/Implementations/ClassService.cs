using SMSystem.App.Interfaces;
using SMSystem.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IEnumerable<Classes> GetAllClasses()
        {
           return _classRepository.GetAll();
        }

        public Classes GetById(int id)
        {
            return _classRepository.GetById(id);
        }
    }
}
