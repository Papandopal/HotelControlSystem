namespace UseCase.DTOs.AuthorisationDTOs
{
    public record VerifyUserUseCaseDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
