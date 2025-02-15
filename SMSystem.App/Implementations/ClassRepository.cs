using SMSystem.App.Interfaces;
using SMSystem.Data.Context;
using SMSystem.Models.Entities;

namespace SMSystem.App.Implementations
{
    public class ClassRepository : Repository<Classes>, IClassRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
