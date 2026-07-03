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
        public void CreateHotel(CreateHotelUseCaseDTO createHotelUseCaseDTO);
        public void UpdateHotel(UpdateHotelUseCaseDTO updateHotelUseCaseDTO);
        public void SetHotelManager(HotelManagerAppointmentUseCaseDTO hotelManagerAppointmentUseCaseDTO);
        public List<HotelInfoUseCaseDTO> GetAllHotels();
        public List<HotelInfoUseCaseDTO> GetHotelsByManagerId(int id);
        public List<HotelInfoUseCaseDTO> GetHotelsByPlace(string country, string? city = null);
        public List<HotelInfoUseCaseDTO> GetHotelsByRating(int rating);
        public List<HotelInfoUseCaseDTO> SortHotelsByRating();
        public List<HotelInfoUseCaseDTO> SortHotelsByName();

    }
}
