using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;

namespace HotelControlSystem.Validators.HotelValidators
{
    public class CreateHotelValidator : AbstractValidator<CreateHotelUseCaseDTO>
    {
        public CreateHotelValidator(UserMainInfoDTO currentUserMainInfo, IUnitOfWork unitOfWork) 
        {
            RuleFor(x=>x.ManagerId).Must(managerId =>
            {
                unitOfWork.StartTransaction();

                var manager = unitOfWork.Users.GetById(managerId);

                unitOfWork.Commit();

                return manager.Role == UserRole.HotelManager;
            }).WithMessage("incoming \"manager id\" is not id of hotel manager");

            RuleFor(x => x.Name).Must(managerName => 
            {
                return currentUserMainInfo.Role == UserRole.Admin;
            }).WithMessage("Access denied");

            RuleFor(x => x.Name).Must((dto, name)  =>
            {
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
