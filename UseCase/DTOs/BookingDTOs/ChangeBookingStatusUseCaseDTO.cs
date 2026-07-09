using DoMain.Enums;

namespace UseCase.DTOs.BookingDTOs
{
    public class ChangeBookingStatusUseCaseDTO
    {
        public int Id { get; init; }
        public BookingStatus NewStatus { get; set; }
    }
}
