using DoMain.Enums;

namespace DoMain.Entities
{
    public class User
    {
        public int Id { get; init; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Unauthorised;
        public bool isDeleted { get; set; } = false;
        public DateTime CreatedAt { get; } = DateTime.Now;

    }
}
