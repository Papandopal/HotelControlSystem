namespace UseCase.Exceptions
{
    internal class AuthorisationFailedException : Exception
    {
        public override string Message { get; }
        public AuthorisationFailedException(string? message)
        {
            Message = message ?? string.Empty;
        }
    }
}
