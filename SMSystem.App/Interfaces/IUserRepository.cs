using SMSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.App.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUser>
    {
        AspNetUser? GetByStringId(string id);
        List<AspNetUser> GetAllWithRoles();


    }
}
