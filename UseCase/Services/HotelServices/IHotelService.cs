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
        public bool IsExists(int id);
        public void Create(CreateHotelUseCaseDTO createHotelUseCaseDTO);
        public void Update(UpdateHotelUseCaseDTO updateHotelUseCaseDTO);
        public void SetHotelManager(HotelManagerAppointmentUseCaseDTO hotelManagerAppointmentUseCaseDTO);
        public List<HotelInfoUseCaseDTO> GetAllHotels();
        public HotelInfoUseCaseDTO GetById(int id);
        public List<HotelInfoUseCaseDTO> GetHotelsByManagerId(int id);
        public List<HotelInfoUseCaseDTO> GetHotelsByPlace(string country, string? city = null);
        public List<HotelInfoUseCaseDTO> GetHotelsByRating(int rating);
        public List<HotelInfoUseCaseDTO> GetSortedHotelsByRating();
        public List<HotelInfoUseCaseDTO> GetSortedHotelsByName();

    }
}
