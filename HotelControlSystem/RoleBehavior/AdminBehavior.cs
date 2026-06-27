using Adapters.Controllers.Console;
using AutoMapper;
using DoMain.Enums;
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
            Actions.AddRange(GetAllUsers, DeleteUser, PromoteUser);
        }

        private void GetAllUsers()
        {
            List<UserInfoConsoleDTO> users = mapper.Map<List<UserInfoConsoleDTO>>(userController.GetAllUsers());
            paginator.SetItems(users);
            paginator.StartPagination();
        }

        private void DeleteUser()
        {
            int userId;
            Input.GetItem("Id: ", out userId);
            userController.DeleteUserById(userId);
            Output.WriteLine("User deleted");
        }

        private void PromoteUser()
        {
            int userId;
            int new_user_role = (int)UserRole.Unauthorised;
            Input.GetItem("Id: ", out userId);
            while(new_user_role <= (int)UserRole.Unauthorised || new_user_role > (int)UserRole.Admin) Input.GetItem("New user role: ", out new_user_role);

            userController.PromoteUserById(userId, (UserRole)new_user_role);
            Output.WriteLine($"User {userId} promoted");
        }

    }
}
