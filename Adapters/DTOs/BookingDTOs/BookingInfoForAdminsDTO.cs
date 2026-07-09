using DoMain.Enums;

namespace Adapters.DTOs.BookingDTOs
{
    public class BookingInfoForAdminsDTO
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal SaleProcent { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
    }
}
