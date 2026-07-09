namespace HotelControlSystem.Exceptions
{
    public class ServiceNotFoundException: Exception
    {
        public override string Message { get; }
        public ServiceNotFoundException(string? message) 
        {
            Message = message ?? string.Empty;
        }
    }
}
