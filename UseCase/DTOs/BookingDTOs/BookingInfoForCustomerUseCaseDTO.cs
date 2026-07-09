using DoMain.Enums;

namespace UseCase.DTOs.BookingDTOs
{
    public class BookingInfoForCustomerUseCaseDTO
    {
        public int Id { get; init; } 
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
