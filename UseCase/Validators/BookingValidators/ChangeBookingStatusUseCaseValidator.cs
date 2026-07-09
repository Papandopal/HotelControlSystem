using FluentValidation;
using UseCase.DTOs.BookingDTOs;

namespace UseCase.Validators.BookingValidators
{
    public class ChangeBookingStatusUseCaseValidator : AbstractValidator<ChangeBookingStatusUseCaseDTO>
    {
        public ChangeBookingStatusUseCaseValidator()
        {

        }
    }
}
