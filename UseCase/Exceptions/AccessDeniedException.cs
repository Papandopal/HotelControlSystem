namespace UseCase.Exceptions
{
    internal class AccessDeniedException: Exception
    {
        public override string Message { get; }
        public AccessDeniedException(string? message) 
        {
            Message = message ?? string.Empty;
        }
    }
}
