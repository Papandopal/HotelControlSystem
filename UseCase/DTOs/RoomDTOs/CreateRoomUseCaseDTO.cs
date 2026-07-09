using DoMain.Enums;

namespace UseCase.DTOs.RoomDTOs
{
    public class CreateRoomUseCaseDTO
    {
        public int HotelId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string[] Amenities { get; set; } = Array.Empty<string>();
        public double Area { get; set; }
    }
}
