using DoMain.Enums;

namespace HotelControlSystem.DTOs.BookingDTOs
{
    public class BookingInfoForAdminsConsoleDTO
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal SaleProcent { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}\n" +
                   $"User id: {UserId}\n" +
                   $"Room id: {RoomId}\n" +
                   $"Check in date: {CheckInDate}\n" +
                   $"Check out date: {CheckOutDate}\n" +
                   $"Sale procent: {SaleProcent}\n" +
                   $"Total price: {TotalPrice}\n" +
                   $"Status: {Status}";
        }
    }
}
