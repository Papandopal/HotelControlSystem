using System.Diagnostics.Metrics;
using Adapters.Controllers.Console;
using Adapters.DTO.HotelDTOs;
using Adapters.DTOs.HotelDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTO.HotelDTOs;
using HotelControlSystem.DTO.UserDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
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

        private Paginator<UserInfoConsoleDTO> userPaginator;
        private Paginator<HotelInfoConsoleDTO> hotelPaginator;
        public AdminBehavior(UserController userController, HotelController hotelController,
            Paginator<UserInfoConsoleDTO> userPaginator, Paginator<HotelInfoConsoleDTO> hotelPaginator,
            IMapper mapper)
        {
            this.userController = userController;
            this.hotelController = hotelController;

            this.userPaginator = userPaginator;
            this.hotelPaginator = hotelPaginator;

            this.mapper = mapper;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetAllUsersAction, DeleteUserAction, PromoteUserAction, CreateHotelAction,
                ChangeHotelManagerAction, UpdateHotelAction);
        }

        //actions with users
        private void GetAllUsersAction()
        {
            List<UserInfoConsoleDTO> users = mapper.Map<List<UserInfoConsoleDTO>>(userController.GetAllUsers());
            userPaginator.SetItems(users);
            userPaginator.StartPagination();
        }

        private void DeleteUserAction()
        {
            int userId;
            Input.GetItem("Id: ", out userId);
            userController.DeleteUserById(userId);
            Output.WriteLine("User deleted");
        }

        private void PromoteUserToHotelManager(int user_id)
        {
            userController.PromoteUser(user_id, UserRole.HotelManager);
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
                    PromoteUserToHotelManager(user_id);
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

        //actions with hotels

        private CreateHotelConsoleDTO GetCreateHotelConsoleDTO()
        {
            string country, city, address, name;
            int managerId;

            Input.GetItem("Country: ", out country);
            Input.GetItem("City: ", out city);
            Input.GetItem("Address: ", out address);
            Input.GetItem("Name: ", out name);
            Input.GetItem("Manager Id: ", out managerId);

            return new CreateHotelConsoleDTO
            { Country = country, City = city, Address = address, Name = name, ManagerId = managerId };
        }

        private void CreateHotelAction()
        {
            var createHotelConsoleDTO = GetCreateHotelConsoleDTO();

            hotelController.Create(mapper.Map<CreateHotelDTO>(createHotelConsoleDTO));
        }

        private void ChangeHotelManagerAction()
        {
            int hotel_id;
            Input.GetItem("Hotel id: ", out hotel_id);

            while (!hotelController.IsExists(hotel_id))
            {
                Output.WriteLine("Hotel not found");
                Input.GetItem("Hotel id: ", out hotel_id);
            }

            int user_id;
            Input.GetItem("Manager id: ", out user_id);

            while (!userController.UserIsExists(user_id))
            {
                Output.WriteLine("Manager not found");
                Input.GetItem("Manager id: ", out user_id);
            }

            HotelManagerAppointmentConsoleDTO hotelManagerAppointmentConsoleDTO =
                new HotelManagerAppointmentConsoleDTO { HotelId = hotel_id, ManagerId = user_id };

            hotelController.SetHotelManager(mapper.Map<HotelManagerAppointmentDTO>(hotelManagerAppointmentConsoleDTO));
        }

        private UpdateHotelConsoleDTO CreateUpdateHotelConsoleDTO(UpdateHotelConsoleDTO updatedHotel)
        {
            string? country, city, address, name;

            Input.TryGetItem("Country: ", out country);
            Input.TryGetItem("City: ", out city);
            Input.TryGetItem("Address: ", out address);
            Input.TryGetItem("Name: ", out name);

            var new_hotel_info = new UpdateHotelConsoleDTO
            {
                Id = updatedHotel.Id,
                Country = country ?? updatedHotel.Country,
                City = city ?? updatedHotel.City,
                Address = address ?? updatedHotel.Address,
                Name = name ?? updatedHotel.Name
            };

            return new_hotel_info;
        }

        private void UpdateHotelAction()
        {
            int hotel_id;
            Input.GetItem("Hotel id: ", out hotel_id);

            while (!hotelController.IsExists(hotel_id))
            {
                Output.WriteLine("Hotel not found");
                Input.GetItem("Hotel id: ", out hotel_id);
            }

            UpdateHotelConsoleDTO updatedHotel = mapper.Map<UpdateHotelConsoleDTO>(hotelController.GetById(hotel_id));

            UpdateHotelConsoleDTO updateHotelConsoleDTO = CreateUpdateHotelConsoleDTO(updatedHotel);

            hotelController.Update(mapper.Map<UpdateHotelDTO>(updateHotelConsoleDTO));
        }

    }
}
