using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.BookingDTOs;

namespace UseCase.Services.BookingServices
{
    public class BookingService(IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<ChangeBookingStatusUseCaseDTO> changeStatusValidator, 
        IValidator<CreateBookingUseCaseDTO> createValidator) : IBookingService
    {
        public event IBookingService.bookingComplited BookingComplited;

        public void Cancel(int id)
        {
            unitOfWork.StartTransaction();

            var booking = unitOfWork.Bookings.GetById(id);

            booking.Cancel();

            unitOfWork.Bookings.Update(booking);

            unitOfWork.Commit();
        }

        public void ChangeStatus(ChangeBookingStatusUseCaseDTO changeBookingStatusUseCaseDTO)
        {
            changeStatusValidator.ValidateAndThrow(changeBookingStatusUseCaseDTO);

            unitOfWork.StartTransaction();

            var booking = unitOfWork.Bookings.GetById(changeBookingStatusUseCaseDTO.Id); 

            booking.ChangeStatus(changeBookingStatusUseCaseDTO.NewStatus);

            if(changeBookingStatusUseCaseDTO.NewStatus == BookingStatus.Complited) 
                BookingComplited.Invoke(mapper.Map<BookingComplitedUseCaseDTO>(booking));

            unitOfWork.Bookings.Update(booking);

            unitOfWork.Commit();
        }

        public void Create(CreateBookingUseCaseDTO createBookingUseCaseDTO)
        {
            createValidator.ValidateAndThrow(createBookingUseCaseDTO);

            unitOfWork.StartTransaction();

            var related_room = unitOfWork.Rooms.GetById(createBookingUseCaseDTO.RoomId);
            var related_user = unitOfWork.Users.GetById(createBookingUseCaseDTO.UserId);

            createBookingUseCaseDTO.User = related_user;
            createBookingUseCaseDTO.Room = related_room;

            var new_booking = mapper.Map<Booking>(createBookingUseCaseDTO);

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

            var bookings = unitOfWork.Bookings.GetBookingsByUserId(userId).ToList();

            unitOfWork.Commit();

            return mapper.Map<List<BookingInfoForCustomerUseCaseDTO>>(bookings);
        }
    }
}
