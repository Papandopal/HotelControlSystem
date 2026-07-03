
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
        public bool IsExists(int id)
        {
            return hotelService.IsExists(id);
        }
        public void Create(CreateHotelDTO createHotelDTO)
        {
            hotelService.Create(mapper.Map<CreateHotelUseCaseDTO>(createHotelDTO));
        }
        public void Update(UpdateHotelDTO updateHotelDTO)
        {
            hotelService.Update(mapper.Map<UpdateHotelUseCaseDTO>(updateHotelDTO));
        }
        public void SetHotelManager(HotelManagerAppointmentDTO hotelManagerAppointmentDTO)
        {
            hotelService.SetHotelManager(mapper.Map<HotelManagerAppointmentUseCaseDTO>(hotelManagerAppointmentDTO));
        }
        public List<HotelInfoDTO> GetAllHotels()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetAllHotels());
        }
        public UpdateHotelDTO GetById(int id)
        {
            return mapper.Map<UpdateHotelDTO>(hotelService.GetById(id));
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
        public List<HotelInfoDTO> GetSortedHotelsByRating()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetSortedHotelsByRating());
        }
        public List<HotelInfoDTO> GetSortedHotelsByName()
        {
            return mapper.Map<List<HotelInfoDTO>>(hotelService.GetSortedHotelsByName());
        }
    }
}
