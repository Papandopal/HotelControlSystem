
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTO.HotelDTOs;
using AutoMapper;
using UseCase.DTOs.HotelDTOs;
using UseCase.Services.HotelServices;

namespace Adapters.Controllers.Console
{
    public class HotelController(IHotelService hotelService, IMapper mapper)
    {
        public bool HotelIsExists(int id)
        {
            return hotelService.HotelIsExists(id);
        }

        public void SetHotelManager(HotelManagerAppointmentDTO hotelManagerAppointmentDTO)
        {
            hotelService.SetHotelManager(mapper.Map<HotelManagerAppointmentUseCaseDTO>(hotelManagerAppointmentDTO));
        }
    }
}
