using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;
using UseCase.Database;
using UseCase.DTOs.UserDTOs;
using UseCase.Services.AuthorisationServices.DTO;

namespace UseCase.Services.UserServices
{
    public interface IUserService
    {
        public List<UserInfoUseCaseDTO> GetAllUsers();
        public void DeleteUserById(int id); 
        public void PromoteUserById(int id, UserRole new_role);
    }
}
