using DoMain.Enums;

namespace HotelControlSystem.DTOs.RoomDTOs
{
    internal class CreateRoomConsoleDTO
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
