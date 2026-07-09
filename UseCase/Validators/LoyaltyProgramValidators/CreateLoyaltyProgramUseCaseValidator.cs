using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.LoyaltyProgrammDTOs;

namespace UseCase.Validators.LoyaltyProgramValidators
{
    public class CreateLoyaltyProgramUseCaseValidator : AbstractValidator<CreateLoyaltyProgramUseCaseDTO>
    {
        public CreateLoyaltyProgramUseCaseValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId).Must(userId =>
            {
                unitOfWork.StartTransaction();

                var isExists = unitOfWork.LoyaltyPrograms.IsExistsByUserId(userId);

                unitOfWork.Commit();

                if (isExists) return false;
                return true;
            }).WithMessage("loyalty program exists");
        }
    }
}
