using DoMain.Enums;

namespace HotelControlSystem.DTOs.BookingDTOs
{
    public class ChangeBookingStatusConsoleDTO
    {
        public int Id { get; init; }
        public BookingStatus NewStatus { get; set; }
    }
}
