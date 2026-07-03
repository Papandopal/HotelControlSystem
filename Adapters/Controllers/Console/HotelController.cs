
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTO.HotelDTOs;
using Adapters.DTOs.HotelDTOs;
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
        public void CreateHotel(CreateHotelDTO createHotelDTO)
        {
            hotelService.CreateHotel(mapper.Map<CreateHotelUseCaseDTO>(createHotelDTO));
        }
        public void UpdateHotel(UpdateHotelDTO updateHotelDTO)
        {
            hotelService.UpdateHotel(mapper.Map<UpdateHotelUseCaseDTO>(updateHotelDTO));
        }
        public void SetHotelManager(HotelManagerAppointmentDTO hotelManagerAppointmentDTO)
        {
            hotelService.SetHotelManager(mapper.Map<HotelManagerAppointmentUseCaseDTO>(hotelManagerAppointmentDTO));
        }
        public List<HotelInfoDTO> GetAllHotels()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetAllHotels());
        }
        public List<HotelInfoDTO> GetHotelsByManagerId(int id)
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetAllHotels());
        }
        public List<HotelInfoDTO> GetHotelsByPlace(string country, string? city = null)
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetHotelsByPlace(country, city));
        }
        public List<HotelInfoDTO> GetHotelsByRating(int rating)
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetHotelsByRating(rating));
        }
        public List<HotelInfoDTO> SortHotelsByRating()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.SortHotelsByRating());
        }
        public List<HotelInfoDTO> SortHotelsByName()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.SortHotelsByName());
        }
    }
}
