using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTO.UserDTOs
{
    public class UserInfoConsoleDTO
    {
        public int Id { get; init; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public override string ToString()
        {
            return 
                $"Id: {Id}\n" +
                $"Role: {Role}\n" +
                $"Name: {UserName}\n" +
                $"Email: {Email}";
        }
    }
}
