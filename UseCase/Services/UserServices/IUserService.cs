using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Database;
using UseCase.Services.AuthorisationServices.DTO;
using UseCase.Services.UserServices.DTO;

namespace UseCase.Services.UserServices
{
    public interface IUserService
    {
        public List<UserInfoUseCaseDTO> GetAllUsers();
    }
}
