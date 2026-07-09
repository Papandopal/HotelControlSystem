using Adapters.Controllers.Console;
using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
using HotelControlSystem.DTOs.RoomDTOs;
using UseCase.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelControlSystem.RoleBehavior
{
    internal class GeneralBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        IUserSession userSession;

        AuthorisationController userController;
        HotelController hotelController;
        RoomController roomController;

        Paginator<HotelInfoConsoleDTO> hotelPaginator;
        Paginator<RoomInfoConsoleDTO> roomPaginator;

        IMapper mapper;

        public GeneralBehavior(IUserSession userSession, IMapper mapper,
            AuthorisationController userController, HotelController hotelController, RoomController roomController,
            Paginator<HotelInfoConsoleDTO> hotelPaginator, Paginator<RoomInfoConsoleDTO> roomPaginator)
        {
            this.userSession = userSession;

            this.userController = userController;
            this.hotelController = hotelController;
            this.roomController = roomController;

            this.mapper = mapper;
            this.hotelPaginator = hotelPaginator;
            this.roomPaginator = roomPaginator;

            //MethodNames must be called "***Action"
            Actions.AddRange(RegistrationAction, VerifyAction, LogOutAction, 
                GetAllHotelsAction, GetHotelsByPlaceAction, GetHotelsByRatingAction, GetSortedHotelsByNameAction,
                GetDescSortedHotelsByNameAction, GetSortedHotelsByRatingAction, GetDescSortedHotelsByRatingAction,
                GetAllRoomsAction, GetRoomsByHotelIdAction, GetRoomsByTypeAction, GetRoomsByPriceRangeAction, GetRoomsByDateAction,
                GetRoomsByCapacityAction, GetSortedRoomsByCapacityAction, GetDescSortedRoomsByCapacityAction,
                GetSortedRoomsByPriceAction, GetDescSortedRoomsByPriceAction
                );
        }

        private RegistrateUserConsoleDTO GetRegistrateUserConsoleDTO()
        {
            string name, password, email;
            int role = 0;

            Input.GetItem("Name: ", out name);
            Input.GetItem("Password: ", out password);
            Input.GetItem("Email: ", out email);

            while (role <= 0 || role > (int)UserRole.Admin)
            {
                Input.GetItem("Role: ", out role);
            }

            return new RegistrateUserConsoleDTO() { UserName = name, Password = password, Email = email, Role = (UserRole)role };
        }

        private void RegistrationAction()
        {
            RegistrateUserConsoleDTO registrateUserConsole = GetRegistrateUserConsoleDTO();
            RegistrateUserDTO registrateUser = mapper.Map<RegistrateUserDTO>(registrateUserConsole);
            userController.Registration(registrateUser);
        }

        private VerifyUserConsoleDTO GetVerifyUserConsoleDTO()
        {
            string name, password;
            Input.GetItem("Name: ", out name);
            Input.GetItem("Password: ", out password);
            return new VerifyUserConsoleDTO() { UserName = name, Password = password };
        }

        private void VerifyAction()
        {
            VerifyUserConsoleDTO verifyUserConsole = GetVerifyUserConsoleDTO();
            VerifyUserDTO verifyUser = mapper.Map<VerifyUserDTO>(verifyUserConsole);
            userController.Authorisation(verifyUser);
        }

        private void LogOutAction()
        {
            userSession.Reset();
        }

        private void GetAllHotelsAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>(hotelController.GetAllHotels());
            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetHotelsByPlaceAction()
        {
            string country;
            string? city;

            Input.GetItem("Country: ", out country);
            Input.TryGetItem("City: ", out city);

            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
                (hotelController.GetHotelsByPlace(country, city));

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetHotelsByRatingAction()
        {
            int rating;

            Input.GetItem("Rating: ", out rating);

            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetHotelsByRating(rating));

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetSortedHotelsByRatingAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetSortedHotelsByRating());
            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetDescSortedHotelsByRatingAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetDescSortedHotelsByName());

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetSortedHotelsByNameAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetSortedHotelsByName());

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetDescSortedHotelsByNameAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetDescSortedHotelsByName());

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private void GetAllRoomsAction()
        {
            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetAllRooms());

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetRoomsByHotelIdAction()
        {

            int hotelId;
            Input.GetItem("Hotel id: ", out hotelId);

            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetRoomsByHotelId(hotelId));

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetRoomsByTypeAction()
        {
            RoomType roomType;
            Input.GetEnumItem("Room type: ", out roomType);

            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetRoomsByType(roomType));

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetRoomsByCapacityAction()
        {
            int capacity;
            Input.GetItem("Capacity: ", out capacity);

            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetRoomsByCapacity(capacity));

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetRoomsByPriceRangeAction()
        {
            decimal minPrice = 0, maxPrice = decimal.MaxValue;

            Input.TryGetItem("Minimal price(default = 0): ", out minPrice);
            while (minPrice < 0)
            {
                Output.WriteLine("Invalide data");
                Input.TryGetItem("Minimal price(default = 0): ", out minPrice);
            }

            Input.TryGetItem("Maximum price(default = inf): ", out maxPrice);
            if (maxPrice == 0) maxPrice = decimal.MaxValue;
            while (maxPrice < 0 || minPrice > maxPrice)
            {
                Output.WriteLine("Invalide data");
                Input.TryGetItem("Maximum price(default = inf): ", out maxPrice);
                if (maxPrice == 0) maxPrice = decimal.MaxValue;
            }

            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>
                (roomController.GetRoomsByPriceRange(minPrice, maxPrice));

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetRoomsByDateAction()
        {
            DateTime date;
            Input.GetItem("Date: ", out date);

            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetRoomsByDate(date));

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetSortedRoomsByPriceAction()
        {
            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetSortedRoomsByPrice());

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetDescSortedRoomsByPriceAction()
        {
            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetDescSortedRoomsByPrice());

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetSortedRoomsByCapacityAction()
        {
            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetSortedRoomsByCapacity());

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }

        private void GetDescSortedRoomsByCapacityAction()
        {
            List<RoomInfoConsoleDTO> rooms = mapper.Map<List<RoomInfoConsoleDTO>>(roomController.GetDescSortedRoomsByCapacity());

            roomPaginator.SetItems(rooms);
            roomPaginator.StartPagination();
        }
    }
}
