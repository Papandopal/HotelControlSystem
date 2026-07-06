using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers.Console;
using Adapters.DTOs.BookingDTOs;
using AutoMapper;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.BookingDTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class CustomerBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        private UserMainInfoDTO currentUser;
        private IMapper mapper;

        private BookingController bookingController;

        private Paginator<BookingInfoForCustomerConsoleDTO> bookingPaginator;

        public CustomerBehavior(UserMainInfoDTO userMainInfoDTO, IMapper mapper, BookingController bookingController,
            Paginator<BookingInfoForCustomerConsoleDTO> bookingPaginator) 
        {
            currentUser = userMainInfoDTO;
            this.mapper = mapper;

            this.bookingController = bookingController;

            this.bookingPaginator = bookingPaginator;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetAllBookingsAction, CreateBookingAction, CanselBookingAction);
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

            return new CreateBookingConsoleDTO { UserId = currentUser.Id, RoomId = roomId, CheckInDate = (DateTime)checkInDate, CheckOutDate = checkOutDate } ;
        }

        private void GetAllBookingsAction()
        {
            List<BookingInfoForCustomerConsoleDTO> bookings = mapper.Map<List<BookingInfoForCustomerConsoleDTO>>
                (bookingController.GetAllForCustomer(currentUser.Id));

            bookingPaginator.SetItems(bookings);
            bookingPaginator.StartPagination();

        } 

        private void CreateBookingAction()
        {
            CreateBookingConsoleDTO createBookingConsoleDTO = GetCreateBookingConsoleDTO();
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
    }
}
