namespace HotelControlSystem.Exceptions
{
    internal class UserCancelledInputException : Exception
    {
        public override string Message { get; }
        public UserCancelledInputException(string message) 
        {
            Message = message;
        }
    }
}
