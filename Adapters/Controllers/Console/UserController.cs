using Adapters.DTO;
using AutoMapper;
using DoMain.Enums;
using UseCase.Services.UserServices;

namespace Adapters.Controllers.Console
{
    public class UserController(IUserService userService, IMapper mapper)
    {
        public List<UserInfoDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoDTO>>(userService.GetAllUsers());
        }
        
        public void DeleteUserById(int id)
        {
            userService.DeleteUserById(id);
        }

        public void PromoteUserById(int id, UserRole new_role)
        {
            userService.PromoteUserById(id, new_role);
        }
    }
}
