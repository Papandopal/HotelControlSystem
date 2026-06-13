using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTO
{
    internal record UserMainInfoDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Customer;
        public override string ToString()
        {
            return $"{Name} | {Email} | {Role.ToString()}";
        }
    }
}
