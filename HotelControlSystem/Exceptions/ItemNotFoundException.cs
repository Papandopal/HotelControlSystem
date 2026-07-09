namespace HotelControlSystem.Exceptions
{
    internal class ItemNotFoundException : Exception
    {
        public override string Message { get; }
        public ItemNotFoundException(string? message) 
        {
            Message = message ?? string.Empty;
        }
    }
}
