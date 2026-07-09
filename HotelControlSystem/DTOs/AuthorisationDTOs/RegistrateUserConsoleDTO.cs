using DoMain.Enums;

namespace HotelControlSystem.DTOs.AuthorisationDTOs
{
    public record RegistrateUserConsoleDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }

    }
}
