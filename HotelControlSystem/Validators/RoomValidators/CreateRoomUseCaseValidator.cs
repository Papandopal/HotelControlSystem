using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.RoomDTOs;

namespace HotelControlSystem.Validators.RoomValidators
{
    public class CreateRoomUseCaseValidator : AbstractValidator<CreateRoomUseCaseDTO>
    {
        public CreateRoomUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.HotelId).Must(hotelId =>
            {
                unitOfWork.StartTransaction();

                if (!unitOfWork.Hotels.IsExists(hotelId))
                {
                    unitOfWork.Rollback();
                    return false;
                }
                unitOfWork.Commit();
                return true;
            }).WithMessage("Hotel not found");
        }
    }
}
