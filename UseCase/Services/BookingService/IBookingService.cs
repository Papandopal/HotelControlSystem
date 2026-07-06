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
        public List<BookingInfoForUserUseCaseDTO> GetAllForUser(int userId);
        public List<BookingInfoForAdminsUseCaseDTO> GetAll();
        public List<BookingInfoForAdminsUseCaseDTO> GetAllByUser(int userId);
        public List<BookingInfoForAdminsUseCaseDTO> GetAllByRoom(int roomId);
    }
}
