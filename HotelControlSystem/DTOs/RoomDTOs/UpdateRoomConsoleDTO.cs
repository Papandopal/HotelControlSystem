using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTOs.RoomDTOs
{
    internal class UpdateRoomConsoleDTO
    {
        public int Id { get; init; }
        public RoomType? RoomType { get; set; }
        public decimal? PricePerNight { get; set; }
        public int? Capacity { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string[]? Amenities { get; set; } = Array.Empty<string>();
        public double? Area { get; set; }
    }
}
