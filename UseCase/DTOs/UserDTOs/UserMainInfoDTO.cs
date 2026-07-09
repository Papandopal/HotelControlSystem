using DoMain.Enums;

namespace UseCase.DTOs.AuthorisationDTOs
{
    public class UserMainInfoDTO
    {
        public int Id { get; init; }
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
