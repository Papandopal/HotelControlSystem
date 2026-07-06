using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface ILoyaltyProgramRepository : IRepository<LoyaltyProgram>
    {
        public bool IsExistsByUserId(int userId);
    }
}
