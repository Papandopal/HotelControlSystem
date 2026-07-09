using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;

namespace UseCase.Validators.HotelValidators
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
