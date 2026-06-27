using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.Database
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<User> GetByUserName(string userName);
    }
}
