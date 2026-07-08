using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.DTOs.BookingDTOs
{
    public class BookingComplitedUseCaseDTO
    {
        public int UserId { get; init; }
        public int RoomId { get; init; }
        public Room Room { get; init; }
        public DateTime CheckInDate { get; init; }
        public DateTime CheckOutDate { get; init; }
        public decimal SaleProcent { get; set; }
        public decimal TotalPrice { get => (Room.PricePerNight * (CheckOutDate - CheckInDate).Days) * (1 - SaleProcent); }
    }
}
