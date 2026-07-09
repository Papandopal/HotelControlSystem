using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers.Console;
using Adapters.DTOs.BookingDTOs;
using Adapters.DTOs.LoyaltyProgramDTOs;
using AutoMapper;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.BookingDTOs;
using HotelControlSystem.DTOs.LoyaltyProgramDTO;
using UseCase.DTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class CustomerBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        private IUserSession userSession;
        private IMapper mapper;

        private BookingController bookingController;
        private LoyaltyProgramController loyaltyProgramController;

        private Paginator<BookingInfoForCustomerConsoleDTO> bookingPaginator;

        public CustomerBehavior(IUserSession userSession, IMapper mapper, BookingController bookingController,
            LoyaltyProgramController loyaltyProgramController, Paginator<BookingInfoForCustomerConsoleDTO> bookingPaginator) 
        {
            this.userSession = userSession;
            this.mapper = mapper;

            this.bookingController = bookingController;
            this.loyaltyProgramController = loyaltyProgramController;

            this.bookingPaginator = bookingPaginator;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetAllBookingsAction, CreateBookingAction, CanselBookingAction);
        }

        private void GetAllBookingsAction()
        {
            List<BookingInfoForCustomerConsoleDTO> bookings = mapper.Map<List<BookingInfoForCustomerConsoleDTO>>
                (bookingController.GetAllForCustomer(userSession.currentUser.Id));

            bookingPaginator.SetItems(bookings);
            bookingPaginator.StartPagination();

        }

        private CreateBookingConsoleDTO GetCreateBookingConsoleDTO()
        {
            int roomId;
            DateTime? checkInDate;
            DateTime checkOutDate;
            DateTime now = DateTime.Now;    

            Input.GetItem("Room id: ", out roomId);

            Input.TryGetItem("Check in date(default = now): ", out checkInDate);
            if (checkInDate is null) checkInDate = now;

            while(checkInDate < now)
            {
                Output.WriteLine("Invalide data");
                Input.TryGetItem("Check in date(default = now): ", out checkInDate);
                if (checkInDate is null || checkInDate == default(DateTime)) checkInDate = DateTime.Now;
            }

            Input.GetItem("Check out date: ", out checkOutDate);

            while(checkOutDate < checkInDate)
            {
                Output.WriteLine("Invalide data");
                Input.GetItem("Check out date: ", out checkOutDate);
            }

            return new CreateBookingConsoleDTO { UserId = userSession.currentUser.Id, RoomId = roomId, CheckInDate = (DateTime)checkInDate, CheckOutDate = checkOutDate } ;
        }

        private void CallJoinLoyaltyProgram()
        {
            char answer;

            Input.GetItem($"Do you want to join loyalty program?({Symbols.Yes} - yes): ", out answer);

            if(answer == Symbols.Yes)
            {
                var createLoyaltyProgramConsoleDTO = new CreateLoyaltyProgramConsoleDTO { UserId = userSession.currentUser.Id };
                loyaltyProgramController.Create(mapper.Map<CreateLoyaltyProgramDTO>(createLoyaltyProgramConsoleDTO));
            }
        }

        private void CallUseLoyaltyProgram(CreateBookingConsoleDTO createBookingConsoleDTO)
        {
            char answer;
            decimal saleProcent = loyaltyProgramController.GetSaleProcentByUserId(userSession.currentUser.Id);

            Input.GetItem($"You want use a sale on {saleProcent}% for current booking?({(char)Symbols.Yes} - yes): ", out answer);

            if (answer == (char)Symbols.Yes)
            {
                createBookingConsoleDTO.SaleProcent = saleProcent;
            }
        }

        private void CreateBookingAction()
        {
            CreateBookingConsoleDTO createBookingConsoleDTO = GetCreateBookingConsoleDTO();

            if(!loyaltyProgramController.IsExistsByUserId(userSession.currentUser.Id)) CallJoinLoyaltyProgram();
            if(loyaltyProgramController.IsExistsByUserId(userSession.currentUser.Id)) CallUseLoyaltyProgram(createBookingConsoleDTO);

            bookingController.Create(mapper.Map<CreateBookingDTO>(createBookingConsoleDTO));
        }

        private void CanselBookingAction()
        {
            int bookingId;
            Input.GetItem("Booking id: ", out bookingId);

            while (!bookingController.IsExists(bookingId))
            {
                Output.WriteLine("Invalide data");
                Input.GetItem("Booking id: ", out bookingId);
            }

            bookingController.Cancel(bookingId);
        }

        private void RegistrateLoyaltyProgramAction()
        {

        }
    }
}
