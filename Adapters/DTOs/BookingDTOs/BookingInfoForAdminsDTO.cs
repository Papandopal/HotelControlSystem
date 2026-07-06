using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace Adapters.DTOs.BookingDTOs
{
    public class BookingInfoForAdminsDTO
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public BookingStatus Status { get; set; }
    }
}
