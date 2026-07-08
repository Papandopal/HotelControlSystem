using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;
using FluentValidation;
using HotelControlSystem.DataBase.UnitOfWork;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;

namespace HotelControlSystem.Validators.HotelValidators
{
    public class UpdateHotelUseCaseValidator : AbstractValidator<UpdateHotelUseCaseDTO>
    {
        public UpdateHotelUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.Name).Must((dto, name) =>
            {
                if (dto.City is null) return true;

                unitOfWork.StartTransaction();

                var hotels = unitOfWork.Hotels.GetHotelsByCity(dto.City);
                foreach (var item in hotels)
                {
                    if (item.Name == name && item.Country == dto.Country)
                    {
                        unitOfWork.Rollback();
                        return false;
                    }
                }

                unitOfWork.Commit();

                return true;
            }).WithMessage("name must be unique in city");
        }
    }
}
