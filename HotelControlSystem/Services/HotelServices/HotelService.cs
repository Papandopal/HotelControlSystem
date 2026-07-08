using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using FluentValidation.Results;
using HotelControlSystem.DTOs.HotelDTOs;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;
using UseCase.Services.HotelServices;

namespace HotelControlSystem.Services.HotelServices
{
    internal class HotelService(IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<CreateHotelUseCaseDTO> createValidator, IValidator<UpdateHotelUseCaseDTO> updateValidator,
        IValidator<HotelManagerAppointmentUseCaseDTO> appointmentValidator) : IHotelService
    {
        List<HotelInfoUseCaseDTO> hotels = new();
        public bool IsExists(int id)
        {
            unitOfWork.StartTransaction();

            var isExists = unitOfWork.Hotels.IsExists(id);

            unitOfWork.Commit();
            return isExists;
        }
        public HotelInfoUseCaseDTO GetById(int id)
        {
            unitOfWork.StartTransaction();

            var hotel = unitOfWork.Hotels.GetById(id);

            unitOfWork.Commit();
            return mapper.Map<HotelInfoUseCaseDTO>(hotel);
        }
        public void Create(CreateHotelUseCaseDTO createHotelUseCaseDTO)
        {
            createValidator.ValidateAndThrow(createHotelUseCaseDTO);

            unitOfWork.StartTransaction();

            var hotel = mapper.Map<Hotel>(createHotelUseCaseDTO);
            var manager = unitOfWork.Users.GetById(createHotelUseCaseDTO.ManagerId);

            hotel.Manager = manager;
            unitOfWork.Hotels.Add(hotel);

            unitOfWork.Commit();
        }
        public void SetHotelManager(HotelManagerAppointmentUseCaseDTO hotelManagerAppointmentUseCaseDTO)
        {
            appointmentValidator.ValidateAndThrow(hotelManagerAppointmentUseCaseDTO);

            unitOfWork.StartTransaction();

            var hotel = unitOfWork.Hotels.GetById(hotelManagerAppointmentUseCaseDTO.HotelId);
            var new_manager = unitOfWork.Users.GetById(hotelManagerAppointmentUseCaseDTO.ManagerId);

            hotel.Manager = new_manager;
            unitOfWork.Hotels.Update(hotel);

            unitOfWork.Commit();
        }

        public void Update(UpdateHotelUseCaseDTO updateHotelUseCaseDTO)
        {
            updateValidator.ValidateAndThrow(updateHotelUseCaseDTO);

            unitOfWork.StartTransaction();

            var hotel = unitOfWork.Hotels.GetById(updateHotelUseCaseDTO.Id);
            Hotel updated_hotel = mapper.Map(updateHotelUseCaseDTO, hotel);

            unitOfWork.Hotels.Update(updated_hotel);

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

        public List<HotelInfoUseCaseDTO> GetSortedHotelsByRating()
        {
            if (hotels.Count == 0) hotels = GetAllHotels();
            return hotels.OrderByDescending(x => x.Rating).ToList();
        }

        public List<HotelInfoUseCaseDTO> GetDescSortedHotelsByRating()
        {
            hotels = GetSortedHotelsByRating();
            hotels.Reverse();
            return hotels;
        }

        public List<HotelInfoUseCaseDTO> GetSortedHotelsByName()
        {
            if (hotels.Count == 0) hotels = GetAllHotels();
            return hotels.OrderBy(x => x.Name).ToList();
        }

        public List<HotelInfoUseCaseDTO> GetDescSortedHotelsByName()
        {
            hotels = GetSortedHotelsByName();
            hotels.Reverse();
            return hotels;
        }
    }
}
