using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.RoomDTOs;

namespace UseCase.Validators.RoomValidators
{
    public class CreateRoomUseCaseValidator : AbstractValidator<CreateRoomUseCaseDTO>
    {
        public CreateRoomUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.HotelId).Must(hotelId =>
            {
                unitOfWork.StartTransaction();

                if (!unitOfWork.Hotels.IsExists(hotelId))
                {
                    unitOfWork.Rollback();
                    return false;
                }
                unitOfWork.Commit();
                return true;
            }).WithMessage("Hotel not found");
        }
    }
}
