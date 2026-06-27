using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;
using UseCase.Database;
using UseCase.Services.AuthorisationServices.DTO;
using UseCase.Services.UserServices.DTO;

namespace UseCase.Services.UserServices
{
    public interface IUserService
    {
        public List<UserInfoUseCaseDTO> GetAllUsers();
        public void DeleteUserById(int id); 
        public void PromoteUserById(int id, UserRole new_role);
    }
}
