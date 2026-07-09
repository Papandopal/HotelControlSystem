namespace HotelControlSystem.DTOs.AuthorisationDTOs
{
    public record VerifyUserConsoleDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
