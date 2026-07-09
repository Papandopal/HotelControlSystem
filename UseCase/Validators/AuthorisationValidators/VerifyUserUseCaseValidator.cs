using FluentValidation;
using UseCase.DTOs.AuthorisationDTOs;

namespace UseCase.Validators.AuthorisationValidators
{
    public class VerifyUserUseCaseValidator : AbstractValidator<VerifyUserUseCaseDTO>
    {
        public VerifyUserUseCaseValidator() 
        {
            
        }
    }
}
