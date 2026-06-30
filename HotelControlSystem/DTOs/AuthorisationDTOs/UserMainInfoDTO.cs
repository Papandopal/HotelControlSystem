using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace HotelControlSystem.DTO.UserDTOs
{
    public class UserMainInfoDTO
    {
        public int Id { get; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public override string ToString()
        {
            return $"{UserName} | {Email} | {Role.ToString()}";
        }
        public void Reset()
        {
            UserName = string.Empty;
            Email = string.Empty;
            Role = UserRole.Unauthorised;
        }
    }
}
