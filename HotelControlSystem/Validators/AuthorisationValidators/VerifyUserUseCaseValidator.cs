using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.AuthorisationDTOs;

namespace HotelControlSystem.Validators.AuthorisationValidators
{
    public class VerifyUserUseCaseValidator : AbstractValidator<VerifyUserUseCaseDTO>
    {
        public VerifyUserUseCaseValidator() 
        {
            
        }
    }
}
