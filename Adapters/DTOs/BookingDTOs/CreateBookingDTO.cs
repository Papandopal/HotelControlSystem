namespace Adapters.DTOs.BookingDTOs
{
    public class CreateBookingDTO
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal SaleProcent { get; set; }
    }
}
