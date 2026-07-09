namespace Adapters.DTOs.AuthorisationDTOs
{
    public record VerifyUserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
