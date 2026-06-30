using Adapters.Controllers.Console;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTO;
using HotelControlSystem.Exceptions;
using UseCase.Services.UserServices;

namespace HotelControlSystem.RoleBehavior
{
    public class AdminBehavior
    {
        public List<Action> Actions { get; set; } = new List<Action>();

        private UserController userController;
        private HotelController hotelController;

        private IMapper mapper;

        private Paginator<UserInfoConsoleDTO> paginator;
        public AdminBehavior(UserController userController, HotelController hotelController, IMapper mapper, Paginator<UserInfoConsoleDTO> paginator)
        {
            this.userController = userController;
            this.hotelController = hotelController;
            this.mapper = mapper;
            this.paginator = paginator;
            Actions.AddRange(GetAllUsersAction, DeleteUserAction, PromoteUserAction);
        }

        private void GetAllUsersAction()
        {
            List<UserInfoConsoleDTO> users = mapper.Map<List<UserInfoConsoleDTO>>(userController.GetAllUsers());
            paginator.SetItems(users);
            paginator.StartPagination();
        }

        private void DeleteUserAction()
        {
            int userId;
            Input.GetItem("Id: ", out userId);
            userController.DeleteUserById(userId);
            Output.WriteLine("User deleted");
        }

        private void PromoteUserAction()
        {
            int user_id;
            int new_user_role = (int)UserRole.Unauthorised;
            Input.GetItem("Id: ", out user_id);
            Input.GetItem("New user role: ", out new_user_role);

            while (true)
            {
                if (new_user_role == (int)UserRole.HotelManager)
                {
                    int hotel_id;
                    Input.GetItem("Hotel id: ", out hotel_id);

                    while (!hotelController.HotelIsExists(hotel_id))
                    {
                        Output.WriteLine("Hotel not found");
                        Input.GetItem("Hotel id: ", out hotel_id);
                    }

                    userController.PromoteUserToHotelManager(user_id);
                    hotelController.SetHotelManager(hotel_id, user_id);
                    break;
                }
                else if (Enum.IsDefined(typeof(UserRole), new_user_role))
                {
                    Output.WriteLine("Cannot promote user to choosed role");
                    Input.GetItem("New user role: ", out new_user_role);
                }
                else
                {
                    Output.WriteLine("Invalide data");
                    Input.GetItem("New user role: ", out new_user_role);
                }
            }


            Output.WriteLine($"User {user_id} promoted");
        }

        private void CreateHotel()
        {

        }

    }
}
