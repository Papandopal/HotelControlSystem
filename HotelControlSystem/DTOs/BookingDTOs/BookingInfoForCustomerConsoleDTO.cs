using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTOs.BookingDTOs
{
    public class BookingInfoForCustomerConsoleDTO
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}\n" +
                   $"Room id: {RoomId}\n" +
                   $"Check in date: {CheckInDate}\n" +
                   $"Check out date: {CheckOutDate}\n" +
                   $"Status: {Status}";
        }
    }
}
