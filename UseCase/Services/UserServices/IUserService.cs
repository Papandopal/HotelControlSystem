using DoMain.Enums;
using UseCase.DTOs.UserDTOs;

namespace UseCase.Services.UserServices
{
    public interface IUserService
    {
        public bool IsExists(int id);
        public List<UserInfoUseCaseDTO> GetAllUsers();
        public void Delete(int id); 
        public void Promote(int id, UserRole new_role);
    }
}
