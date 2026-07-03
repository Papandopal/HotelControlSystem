using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.DTOs.HotelDTOs;

namespace UseCase.Services.HotelServices
{
    public interface IHotelService
    {
        public bool HotelIsExists(int id);
        public void SetHotelManager(HotelManagerAppointmentUseCaseDTO hotelManagerAppointmentUseCaseDTO);
    }
}
