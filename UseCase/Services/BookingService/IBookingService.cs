using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.DTOs.BookingDTOs;

namespace UseCase.Services.BookingService
{
    public interface IBookingService
    {
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
