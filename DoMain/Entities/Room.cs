using System;
using DoMain.Enums;

namespace DoMain.Entities
{
    public class Room
    {
        private Room() { }
        public Room(Hotel hotel)
        {
            Hotel = hotel;
        }
        public int Id { get; init; }
        public int HotelId { get; init; }
        public Hotel Hotel { get; init; }
        public RoomType RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string[] Amenities { get; set; } = Array.Empty<string>();
        public double Area { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
