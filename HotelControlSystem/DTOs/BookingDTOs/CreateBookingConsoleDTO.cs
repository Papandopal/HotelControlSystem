namespace HotelControlSystem.DTOs.BookingDTOs
{
    public class CreateBookingConsoleDTO
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal SaleProcent { get; set; }
    }
}
