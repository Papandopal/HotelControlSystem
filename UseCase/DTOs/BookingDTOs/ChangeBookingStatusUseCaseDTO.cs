using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace UseCase.DTOs.BookingDTOs
{
    public class ChangeBookingStatusUseCaseDTO
    {
        public int Id { get; init; }
        public BookingStatus NewStatus { get; set; }
    }
}
