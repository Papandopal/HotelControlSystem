namespace HotelControlSystem.Exceptions
{
    public class UnknowRoleException: Exception
    {
        public override string Message { get; }
        public UnknowRoleException(string? message)
        {
            Message = message ?? string.Empty;
        }
    }
}
