using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;
using FluentValidation;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;

namespace HotelControlSystem.Validators.HotelValidators
{
    public class HotelManagerAppointmentUseCaseValidator : AbstractValidator<HotelManagerAppointmentUseCaseDTO>
    {
        public HotelManagerAppointmentUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.ManagerId).Must(managerId =>
            {
                unitOfWork.StartTransaction();

                var new_manager = unitOfWork.Users.GetById(managerId);

                if (new_manager.Role != UserRole.HotelManager)
                {
                    unitOfWork.Rollback();
                    return false;
                }

                unitOfWork.Commit();
                return true;
            }).WithMessage("user is not manager");
        }
    }
}
