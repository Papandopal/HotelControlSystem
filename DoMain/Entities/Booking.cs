using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace DoMain.Entities
{
    public class Booking
    {
        private Booking() {}
        public Booking(User user, Room room) 
        {
            User = user;
            Room = room;    
        }
        public int Id { get; init; }
        public int UserId { get; init; }
        public User User { get; init; } 
        public int RoomId { get; set; }
        public Room Room { get; set; } 
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal? TotalPrice { get => Room.PricePerNight * (CheckOutDate - CheckInDate).Days; }
        public BookingStatus Status { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
