using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers.Console;
using Adapters.DTOs.BookingDTOs;
using Adapters.DTOs.HotelDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.BookingDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
using UseCase.DTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class ManagerBehavior
    {
        public List<Action> Actions { get; set; } = new List<Action>();

        private IUserSession userSession;

        private HotelController hotelController;
        private BookingController bookingController;

        private Paginator<HotelInfoConsoleDTO> hotelPaginator;
        private Paginator<BookingInfoForAdminsConsoleDTO> bookingPaginator;

        private IMapper mapper;
        public ManagerBehavior(IUserSession userSession, HotelController hotelController, BookingController bookingController,
            Paginator<HotelInfoConsoleDTO> hotelPaginator, Paginator<BookingInfoForAdminsConsoleDTO> bookingPaginator, 
            IMapper mapper)
        {
            this.userSession = userSession;

            this.hotelController = hotelController;
            this.bookingController = bookingController;

            this.hotelPaginator = hotelPaginator;
            this.bookingPaginator = bookingPaginator;

            this.mapper = mapper;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetHotelsAction, UpdateHotelAction, GetAllBookingsAction, GetBookingsByUserAction,
                GetBookingsByRoomAction, ChangeBookingStatusAction);
        }

        private void GetHotelsAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
                (hotelController.GetHotelsByManagerId(userSession.currentUser.Id));

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
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

        private void GetAllBookingsAction()
        {
            List<BookingInfoForAdminsConsoleDTO> bookings = 
                mapper.Map<List<BookingInfoForAdminsConsoleDTO>>(bookingController.GetAllByManagerId(userSession.currentUser.Id));

            bookingPaginator.SetItems(bookings);
            bookingPaginator.StartPagination();
        }

        private void GetBookingsByUserAction()
        {
            int userId;
            Input.GetItem("User id: ", out userId);

            List<BookingInfoForAdminsConsoleDTO> bookings =
                mapper.Map<List<BookingInfoForAdminsConsoleDTO>>(bookingController.GetAllByUser(userId));

            bookingPaginator.SetItems(bookings);
            bookingPaginator.StartPagination();
        }

        private void GetBookingsByRoomAction()
        {
            int roomId;
            Input.GetItem("User id: ", out roomId);

            List<BookingInfoForAdminsConsoleDTO> bookings =
                mapper.Map<List<BookingInfoForAdminsConsoleDTO>>(bookingController.GetAllByRoom(roomId));

            bookingPaginator.SetItems(bookings);
            bookingPaginator.StartPagination();
        }

        private ChangeBookingStatusConsoleDTO GetChangeBookingStatusConsoleDTO()
        {
            int bookingId;
            BookingStatus bookingStatus;

            Input.GetItem("Booking id: ", out bookingId);

            while (!bookingController.IsExists(bookingId))
            {
                Output.WriteLine("Invalide data");
                Input.GetItem("Booking id: ", out bookingId);
            }

            Input.GetEnumItem("Booking status: ", out bookingStatus);

            while(bookingStatus != BookingStatus.Confirmed && bookingStatus != BookingStatus.Complited)
            {
                Output.WriteLine("Invalide data");
                Input.GetEnumItem("Booking status: ", out bookingStatus);
            }

            return new ChangeBookingStatusConsoleDTO { Id = bookingId, NewStatus = bookingStatus };
        }
        private void ChangeBookingStatusAction()
        {
            ChangeBookingStatusConsoleDTO changeBookingStatusConsoleDTO = GetChangeBookingStatusConsoleDTO();
            bookingController.ChangeBookingStatus(mapper.Map<ChangeBookingStatusDTO>(changeBookingStatusConsoleDTO));
        }
    }
}
