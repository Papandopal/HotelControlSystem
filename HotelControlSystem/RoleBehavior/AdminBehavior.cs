using System.Diagnostics.Metrics;
using Adapters.Controllers.Console;
using Adapters.DTO.HotelDTOs;
using Adapters.DTOs.HotelDTOs;
using Adapters.DTOs.RoomDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTO.HotelDTOs;
using HotelControlSystem.DTO.UserDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
using HotelControlSystem.DTOs.RoomDTOs;
using HotelControlSystem.Exceptions;
using UseCase.Services.UserServices;

namespace HotelControlSystem.RoleBehavior
{
    public class AdminBehavior
    {
        public List<Action> Actions { get; set; } = new List<Action>();

        private UserController userController;
        private HotelController hotelController;
        private RoomController roomController;

        private IMapper mapper;

        private Paginator<UserInfoConsoleDTO> userPaginator;
        public AdminBehavior(UserController userController, HotelController hotelController, RoomController roomController,
            Paginator<UserInfoConsoleDTO> userPaginator, IMapper mapper)
        {
            this.userController = userController;
            this.hotelController = hotelController;
            this.roomController = roomController;

            this.userPaginator = userPaginator;

            this.mapper = mapper;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetAllUsersAction, DeleteUserAction, PromoteUserAction, CreateHotelAction,
                ChangeHotelManagerAction, UpdateHotelAction, CreateRoomAction, UpdateRoomAction);
        }

        //users actions
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

        private void PromoteUserAction()
        {
            int user_id;
            UserRole new_user_role;
            Input.GetItem("Id: ", out user_id);
            Input.GetEnumItem("New user role: ", out new_user_role);

            while (true)
            {
                if (new_user_role == UserRole.HotelManager)
                {
                    userController.PromoteUser(user_id, new_user_role);
                    break;
                }
                else
                {
                    Output.WriteLine("Cannot promote user to choosed role");
                    Input.GetEnumItem("New user role: ", out new_user_role);
                }
            }

            Output.WriteLine($"User {user_id} promoted");
        }

        //hotels actions

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

        private UpdateHotelConsoleDTO GetUpdateHotelConsoleDTO(int id)
        {
            string? country, city, address, name;

            Input.TryGetItem("Country: ", out country);
            Input.TryGetItem("City: ", out city);
            Input.TryGetItem("Address: ", out address);
            Input.TryGetItem("Name: ", out name);

            var new_hotel_info = new UpdateHotelConsoleDTO
            {
                Id = id,
                Country = country,
                City = city,
                Address = address,
                Name = name
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

            UpdateHotelConsoleDTO updateHotelConsoleDTO = GetUpdateHotelConsoleDTO(hotel_id);

            hotelController.Update(mapper.Map<UpdateHotelDTO>(updateHotelConsoleDTO));
        }

        //room actions

        private CreateRoomConsoleDTO GetCreateRoomConsoleDTO()
        {
            int hotelId, capacity;
            decimal pricePerNight;
            double area;
            string description;
            RoomType roomType;
            string[] amenities = [];

            Input.GetItem("Hotel id: ", out hotelId);
            Input.GetEnumItem("Room type", out roomType);
            Input.GetItem("Capacity: ", out capacity);
            Input.GetItem("Area: ", out area);
            Input.GetItem("Price per night: ", out pricePerNight);
            Input.GetItem("Description: ", out description);

            string? amenities_item;

            while (true)
            {
                Input.TryGetItem($"Amenities№{amenities.Length}(send empty line for end input):", out amenities_item);
                if (amenities_item == null) break;
                amenities = amenities.Append(amenities_item).ToArray();
            }

            return new CreateRoomConsoleDTO
            {
                Amenities = amenities,
                Area = area,
                Capacity = capacity,
                Description = description,
                PricePerNight = pricePerNight,
                RoomType = roomType,
                HotelId = hotelId
            };
        }
        private void CreateRoomAction()
        {
            CreateRoomConsoleDTO createRoomConsoleDTO = GetCreateRoomConsoleDTO();
            roomController.Create(mapper.Map<CreateRoomDTO>(createRoomConsoleDTO));
        }

        private UpdateRoomConsoleDTO GetUpdateRoomConsoleDTO(int id)
        {
            int? capacity;
            decimal? pricePerNight;
            double? area;
            string? description;
            RoomType? roomType;
            string[]? amenities = [];

            Input.TryGetEnumItem("Room type", out roomType);
            Input.TryGetItem("Capacity: ", out capacity);
            Input.TryGetItem("Area: ", out area);
            Input.TryGetItem("Price per night: ", out pricePerNight);
            Input.TryGetItem("Description: ", out description);

            string? amenities_item;

            while (true)
            {
                Input.TryGetItem($"Amenities№{amenities.Length}(send empty line for end input):", out amenities_item);
                if (amenities_item == null) break;
                amenities = amenities.Append(amenities_item).ToArray();
            }
            return new UpdateRoomConsoleDTO { 
                Id = id,
                Amenities = amenities,
                Area = area,
                Capacity = capacity,
                Description = description,
                PricePerNight = pricePerNight,
                RoomType = roomType
            };
        }

        private void UpdateRoomAction()
        {
            int room_id;
            Input.GetItem("Room id:", out room_id);

            while(!roomController.IsExists(room_id))
            {
                Output.WriteLine("Room not found");
                Input.GetItem("Room id:", out room_id);
            }

            UpdateRoomConsoleDTO updateRoomConsoleDTO = GetUpdateRoomConsoleDTO(room_id);

            roomController.Update(mapper.Map<UpdateRoomDTO>(updateRoomConsoleDTO));
        }

    }
}
