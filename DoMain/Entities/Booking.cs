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
        public decimal SaleProcent { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; private set; }
        public bool IsDeleted { get; set; } = false;
        public void Cancel()
        {
            ChangeStatus(BookingStatus.Cancelled);
        }
        public void ChangeStatus(BookingStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
