using DoMain.Enums;
using UseCase.DTOs.UserDTOs;

namespace UseCase.Services.UserServices
{
    public interface IUserService
    {
        public List<UserInfoUseCaseDTO> GetAllUsers();
        public void DeleteUser(int id); 
        public void PromoteUser(int id, UserRole new_role);
    }
}
