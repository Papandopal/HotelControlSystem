using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using HotelControlSystem.DTOs.HotelDTOs;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;
using UseCase.Services.HotelServices;

namespace HotelControlSystem.Services.HotelServices
{
    internal class HotelService(IUnitOfWork unitOfWork, IMapper mapper) : IHotelService
    {
        List<HotelInfoUseCaseDTO> hotels = new();
        public bool HotelIsExists(int id)
        {
            unitOfWork.StartTransaction();

            var hotel = unitOfWork.Hotels.GetById(id);

            unitOfWork.Commit();
            return hotel is not null && !hotel.IsDeleted;
        }
        public void CreateHotel(CreateHotelUseCaseDTO createHotelUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var hotel = mapper.Map<Hotel>(createHotelUseCaseDTO);
            var manager = unitOfWork.Users.GetById(createHotelUseCaseDTO.ManagerId);

            if(manager.Role != UserRole.HotelManager)
            {
                unitOfWork.Rollback();
                throw new UnsuitableItemException("user is not manager");
            }

            hotel.Manager = manager;
            unitOfWork.Hotels.Add(hotel);

            unitOfWork.Commit();
        }
        public void SetHotelManager(HotelManagerAppointmentUseCaseDTO hotelManagerAppointmentUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var hotel = unitOfWork.Hotels.GetById(hotelManagerAppointmentUseCaseDTO.HotelId);
            var new_manager = unitOfWork.Users.GetById(hotelManagerAppointmentUseCaseDTO.ManagerId);

            if (hotel is null)
            {
                unitOfWork.Rollback();
                throw new ItemNotFoundException("hotel not found");
            }
            if (new_manager is null || new_manager.Role != DoMain.Enums.UserRole.HotelManager)
            {
                unitOfWork.Rollback();
                throw new ItemNotFoundException("manager not found");
            }

            if (new_manager.Role != UserRole.HotelManager)
            {
                unitOfWork.Rollback();
                throw new UnsuitableItemException("user is not manager");
            }

            hotel.Manager = new_manager;
            unitOfWork.Hotels.Update(hotel);

            unitOfWork.Commit();
        }

        public void UpdateHotel(UpdateHotelUseCaseDTO updateHotelUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var hotel = mapper.Map<Hotel>(updateHotelUseCaseDTO);
            unitOfWork.Hotels.Update(hotel);

            unitOfWork.Commit();
        }

        public List<HotelInfoUseCaseDTO> GetAllHotels()
        {
            unitOfWork.StartTransaction();

            hotels = mapper.Map<List<HotelInfoUseCaseDTO>>(unitOfWork.Hotels.GetAll());

            unitOfWork.Commit();

            return hotels;
        }

        public List<HotelInfoUseCaseDTO> GetHotelsByManagerId(int id)
        {
            unitOfWork.StartTransaction();

            hotels = mapper.Map<List<HotelInfoUseCaseDTO>>(unitOfWork.Hotels.GetAll().Where(x=>x.ManagerId == id));

            unitOfWork.Commit();

            return hotels;
        }

        public List<HotelInfoUseCaseDTO> GetHotelsByPlace(string country, string? city = null)
        {
            unitOfWork.StartTransaction();

            hotels = mapper.Map<List<HotelInfoUseCaseDTO>>(unitOfWork.Hotels.GetAll().Where(x=>x.Country==country).ToList());
            if(city is not null) hotels = hotels.Where(x=>x.City==city).ToList();

            unitOfWork.Commit();

            return hotels;
        }

        public List<HotelInfoUseCaseDTO> GetHotelsByRating(int rating)
        {
            unitOfWork.StartTransaction();

            hotels = mapper.Map<List<HotelInfoUseCaseDTO>>(unitOfWork.Hotels.GetAll().Where(x=>x.Rating>=rating));

            unitOfWork.Commit();

            return hotels;
        }

        public List<HotelInfoUseCaseDTO> SortHotelsByRating()
        {
            return hotels.OrderByDescending(x => x.Rating).ToList();
        }

        public List<HotelInfoUseCaseDTO> SortHotelsByName()
        {
            return hotels.OrderBy(x => x.Name).ToList();
        }
    }
}
