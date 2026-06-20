using Adapters.DTO;
using AutoMapper;
using UseCase.Services.UserServices;

namespace Adapters.Controllers.Console
{
    public class UserController(IUserService userService, IMapper mapper)
    {
        public List<UserInfoDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoDTO>>(userService.GetAllUsers());
        }
    }
}
