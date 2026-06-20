using Adapters.Controllers.Console;
using AutoMapper;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTO;
using UseCase.Services.UserServices;

namespace HotelControlSystem.RoleBehavior
{
    public class AdminBehavior
    {
        public List<Action> Actions { get; set; } = new List<Action>();
        private UserController userController;
        private IMapper mapper;
        private Paginator<UserInfoConsoleDTO> paginator;
        public AdminBehavior(UserController userController, IMapper mapper, Paginator<UserInfoConsoleDTO> paginator)
        {
            this.userController = userController; 
            this.mapper = mapper;
            this.paginator = paginator;
            Actions.AddRange(GetAllUsers);
        }

        private void GetAllUsers()
        {
            List<UserInfoConsoleDTO> users = mapper.Map<List<UserInfoConsoleDTO>>(userController.GetAllUsers());
            paginator.SetItems(users);
            paginator.StartPagination();
        }

    }
}
