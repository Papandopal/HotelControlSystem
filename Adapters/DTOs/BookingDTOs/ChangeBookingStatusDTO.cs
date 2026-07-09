using DoMain.Enums;

namespace Adapters.DTOs.BookingDTOs
{
    public class ChangeBookingStatusDTO
    {
        public int Id { get; init; }
        public BookingStatus NewStatus { get; set; }
    }
}
