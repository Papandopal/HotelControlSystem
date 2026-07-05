using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using DoMain.Enums;

namespace Adapters.DTOs.RoomDTOs
{
    public class CreateRoomDTO
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
