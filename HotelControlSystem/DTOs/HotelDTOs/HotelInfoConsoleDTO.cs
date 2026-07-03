using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.DTOs.HotelDTOs
{
    public class HotelInfoConsoleDTO
    {
        private int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Rating { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Address: {Country}, {City}, {Address}\n" +
                   $"Rating: {Rating}";
        }
    }
}
