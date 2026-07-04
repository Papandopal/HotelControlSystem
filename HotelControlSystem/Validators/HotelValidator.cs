using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using HotelControlSystem.DTOs.AuthorisationDTOs;

namespace HotelControlSystem.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator(UserMainInfoDTO currentUserMainInfo) 
        {
            RuleFor(x=>x.ManagerId).Must((managerId) =>
            {
                return currentUserMainInfo.Role == UserRole.Admin || currentUserMainInfo.Id == managerId;
            }).WithMessage("Access denaed");
        }
    }
}
