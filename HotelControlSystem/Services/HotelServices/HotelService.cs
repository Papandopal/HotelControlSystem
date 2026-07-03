using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;
using UseCase.Services.HotelServices;

namespace HotelControlSystem.Services.HotelServices
{
    internal class HotelService(IUnitOfWork unitOfWork) : IHotelService
    {
        public bool HotelIsExists(int id)
        {
            unitOfWork.StartTransaction();
            var hotel = unitOfWork.Hotels.GetById(id);
            unitOfWork.Commit();
            return hotel is not null;
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

            hotel.Manager = new_manager;
            unitOfWork.Hotels.Update(hotel);
            unitOfWork.Commit();
        }
    }
}
