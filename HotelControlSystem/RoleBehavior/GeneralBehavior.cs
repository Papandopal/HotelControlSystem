using Adapters.Controllers.Console;
using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.HotelDTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class GeneralBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        UserMainInfoDTO userMainInfoDTO;
        AuthorisationController userController;
        HotelController hotelController;
        Paginator<HotelInfoConsoleDTO> hotelPaginator;

        IMapper mapper;

        public GeneralBehavior(UserMainInfoDTO userMainInfoDTO, IMapper mapper, Paginator<HotelInfoConsoleDTO> hotelPaginator,
            AuthorisationController userController, HotelController hotelController)
        {
            this.userMainInfoDTO = userMainInfoDTO;

            this.userController = userController;
            this.hotelController = hotelController;

            this.mapper = mapper;
            this.hotelPaginator = hotelPaginator;

            //MethodNames must be called "***Action"
            Actions.AddRange(RegistrationAction, VerifyAction, LogOutAction, GetAllHotelsAction, GetHotelsByPlaceAction,
                GetHotelsByRatingAction, GetSortedHotelsByNameAction, GetSortedHotelsByRatingAction);
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
            AuthorisedUserDTO authorisedUserDTO = userController.Registration(registrateUser);
            mapper.Map(authorisedUserDTO, userMainInfoDTO);
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
            AuthorisedUserDTO authorisedUser = userController.Authorisation(verifyUser);
            mapper.Map(authorisedUser, userMainInfoDTO);
        } 

        private void LogOutAction()
        {
            userMainInfoDTO.Reset();
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

        private void GetSortedHotelsByNameAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
               (hotelController.GetSortedHotelsByName());

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }
    }
}
