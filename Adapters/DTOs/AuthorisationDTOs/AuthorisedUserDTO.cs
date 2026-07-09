using DoMain.Enums;

namespace Adapters.DTOs.AuthorisationDTOs
{
    public record AuthorisedUserDTO
    {
        public int Id { get; init; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
