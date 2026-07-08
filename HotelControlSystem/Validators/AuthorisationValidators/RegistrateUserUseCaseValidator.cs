using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.DTOs.AuthorisationDTOs;

namespace HotelControlSystem.Validators.AuthorisationValidators
{
    public class RegistrateUserUseCaseValidator : AbstractValidator<RegistrateUserUseCaseDTO>
    {
        public RegistrateUserUseCaseValidator() 
        {

        }
    }
}
