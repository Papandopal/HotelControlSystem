namespace HotelControlSystem.Exceptions
{
    internal class UnsuitableItemException : Exception
    {
        public override string Message { get; }
        public UnsuitableItemException(string? message)
        {
            Message = message ?? string.Empty;
        }
    }
}
