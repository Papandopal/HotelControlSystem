using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTOs.BookingDTOs;
using AutoMapper;
using DoMain.Entities;
using UseCase.DTOs.BookingDTOs;
using UseCase.Services.BookingService;

namespace Adapters.Controllers.Console
{
    public class BookingController(IBookingService bookingService, IMapper mapper)
    {
        public void Create(CreateBookingDTO createBookingDTO)
        {
            bookingService.Create(mapper.Map<CreateBookingUseCaseDTO>(createBookingDTO));
        }
        public void Cancel(int id)
        {
            bookingService.Cancel(id);
        }

        public void ChangeBookingStatus(ChangeBookingStatusDTO changeBookingStatusDTO)
        {
            bookingService.ChangeStatus(mapper.Map<ChangeBookingStatusUseCaseDTO>(changeBookingStatusDTO));
        }

        public bool IsExists(int id)
        {
            return bookingService.IsExists(id);
        }

        public List<BookingInfoForCustomerDTO> GetAllForCustomer(int userId)
        {
            return mapper.Map<List<BookingInfoForCustomerDTO>>(bookingService.GetAllForCustomer(userId));
        }

        public List<BookingInfoForAdminsDTO> GetAll()
        {
            return mapper.Map<List<BookingInfoForAdminsDTO>>(bookingService.GetAll());
        }

        public List<BookingInfoForAdminsDTO> GetAllByUser(int userId)
        {
            return mapper.Map<List<BookingInfoForAdminsDTO>>(bookingService.GetAllByUser(userId));
        }

        public List<BookingInfoForAdminsDTO> GetAllByRoom(int roomId)
        {
            return mapper.Map<List<BookingInfoForAdminsDTO>>(bookingService.GetAllByRoom(roomId));
        }

        public List<BookingInfoForAdminsDTO> GetAllByManagerId(int managerId)
        {
            return mapper.Map<List<BookingInfoForAdminsDTO>>(bookingService.GetAllByManagerId(managerId));
        }

    }
}
