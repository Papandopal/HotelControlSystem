using FluentValidation;
using UseCase.DTOs.AuthorisationDTOs;

namespace UseCase.Validators.AuthorisationValidators
{
    public class RegistrateUserUseCaseValidator : AbstractValidator<RegistrateUserUseCaseDTO>
    {
        public RegistrateUserUseCaseValidator() 
        {

        }
    }
}
