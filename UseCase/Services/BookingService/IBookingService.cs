using UseCase.DTOs.BookingDTOs;

namespace UseCase.Services.BookingServices
{
    public interface IBookingService
    {
        public delegate void bookingComplited(BookingComplitedUseCaseDTO bookingCreatedUseCaseDTO);
        public event bookingComplited BookingComplited;
        public void Create(CreateBookingUseCaseDTO createBookingUseCaseDTO);
        public void Cancel(int id);
        public void ChangeStatus(ChangeBookingStatusUseCaseDTO changeBookingStatusUseCaseDTO);
        public bool IsExists(int id);
        public List<BookingInfoForCustomerUseCaseDTO> GetAllForCustomer(int userId);
        public List<BookingInfoForAdminsUseCaseDTO> GetAll();
        public List<BookingInfoForAdminsUseCaseDTO> GetAllByUser(int userId);
        public List<BookingInfoForAdminsUseCaseDTO> GetAllByRoom(int roomId);
        public List<BookingInfoForAdminsUseCaseDTO> GetAllByManagerId(int managerId);
    }
}
