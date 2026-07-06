using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using UseCase.Database;
using UseCase.DTOs.BookingDTOs;
using UseCase.Services.BookingService;

namespace HotelControlSystem.Services.BookingServices
{
    public class BookingService(IUnitOfWork unitOfWork, IMapper mapper) : IBookingService
    {
        public event IBookingService.bookingCreated BookingCreated;

        public void Cancel(int id)
        {
            unitOfWork.StartTransaction();

            unitOfWork.Bookings.GetById(id).Status = BookingStatus.Cancelled; //MUST REDO

            unitOfWork.Commit();
        }

        public void ChangeStatus(ChangeBookingStatusUseCaseDTO changeBookingStatusUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            unitOfWork.Bookings.GetById(changeBookingStatusUseCaseDTO.Id).Status = changeBookingStatusUseCaseDTO.NewStatus; //MUST REDO

            unitOfWork.Commit();
        }

        public void Create(CreateBookingUseCaseDTO createBookingUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            //MOVE ON VALIDATOR

            var bookings = unitOfWork.Bookings.GetBookingsByRoomId(createBookingUseCaseDTO.RoomId);

            foreach (var booking in bookings)
            {
                if (booking.Status == BookingStatus.Cancelled || booking.Status == BookingStatus.Complited) continue;

                if((booking.CheckInDate < createBookingUseCaseDTO.CheckInDate &&
                    createBookingUseCaseDTO.CheckInDate < booking.CheckOutDate) ||
                    (booking.CheckInDate < createBookingUseCaseDTO.CheckOutDate &&
                    createBookingUseCaseDTO.CheckOutDate < booking.CheckOutDate))
                {
                    throw new Exception("cannot booking because room not empty");
                }
            }

            var related_room = unitOfWork.Rooms.GetById(createBookingUseCaseDTO.RoomId);
            var related_user = unitOfWork.Users.GetById(createBookingUseCaseDTO.UserId);

            createBookingUseCaseDTO.User = related_user;
            createBookingUseCaseDTO.Room = related_room;

            var new_booking = mapper.Map<Booking>(createBookingUseCaseDTO);

            BookingCreated.Invoke(mapper.Map<BookingCreatedUseCaseDTO>(new_booking));

            unitOfWork.Bookings.Add(new_booking);

            unitOfWork.Commit();
        }

        public bool IsExists(int id)
        {
            return unitOfWork.Bookings.IsExists(id);
        }

        public List<BookingInfoForAdminsUseCaseDTO> GetAll()
        {
            unitOfWork.StartTransaction();

            var bookings = unitOfWork.Bookings.GetAll();

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForAdminsUseCaseDTO>>(bookings);
        }

        public List<BookingInfoForAdminsUseCaseDTO> GetAllByManagerId(int managerId)
        {
            unitOfWork.StartTransaction();

            var bookings = unitOfWork.Bookings.GetBookingsByManagerId(managerId);

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForAdminsUseCaseDTO>>(bookings);
        }

        public List<BookingInfoForAdminsUseCaseDTO> GetAllByRoom(int roomId)
        {
            unitOfWork.StartTransaction();

            var bookings = unitOfWork.Bookings.GetBookingsByRoomId(roomId);

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForAdminsUseCaseDTO>>(bookings);
        }

        public List<BookingInfoForAdminsUseCaseDTO> GetAllByUser(int userId)
        {
            unitOfWork.StartTransaction();

            var bookings = unitOfWork.Bookings.GetBookingsByUserId(userId);

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForAdminsUseCaseDTO>>(bookings);
        }

        public List<BookingInfoForCustomerUseCaseDTO> GetAllForCustomer(int userId)
        {
            unitOfWork.StartTransaction();

            var bookings = unitOfWork.Bookings.GetBookingsByUserId(userId);

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForCustomerUseCaseDTO>>(bookings);
        }
    }
}
