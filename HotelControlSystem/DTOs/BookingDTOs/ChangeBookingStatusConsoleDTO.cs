using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTOs.BookingDTOs
{
    public class ChangeBookingStatusConsoleDTO
    {
        public int Id { get; init; }
        public BookingStatus NewStatus { get; set; }
    }
}
