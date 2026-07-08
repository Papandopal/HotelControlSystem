using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.DTOs.HotelDTOs
{
    public class UpdateHotelDTO
    {
        public int Id { get; init; }
        public string? Name { get; set; } 
        public string? City { get; set; } 
        public string? Country { get; set; } 
        public string? Address { get; set; } 
    }
}
