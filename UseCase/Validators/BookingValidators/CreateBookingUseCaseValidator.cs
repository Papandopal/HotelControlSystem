using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.BookingDTOs;

namespace UseCase.Validators.BookingValidators
{
    public class CreateBookingUseCaseValidator : AbstractValidator<CreateBookingUseCaseDTO>
    {
        public CreateBookingUseCaseValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.RoomId).Must((dto, roomId) => 
            {
                unitOfWork.StartTransaction();

                var bookings = unitOfWork.Bookings.GetBookingsByRoomId(roomId);

                foreach (var booking in bookings)
                {
                    if (booking.Status == BookingStatus.Cancelled || booking.Status == BookingStatus.Complited) continue;

                    if ((booking.CheckInDate < dto.CheckInDate &&
                        dto.CheckInDate < booking.CheckOutDate) ||
                        (booking.CheckInDate < dto.CheckOutDate &&
                        dto.CheckOutDate < booking.CheckOutDate))
                    {
                        unitOfWork.Rollback();
                        return false;
                    }
                }

                unitOfWork.Commit();
                return true;
            }).WithMessage("cannot booking because room not empty in this days");
        }
    }
}
