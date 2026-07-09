namespace HotelControlSystem.ConsoleIO
{
    public static class SpecialKeys
    {
        public static readonly ConsoleKey RunAction = ConsoleKey.Enter;
        public static readonly ConsoleKey NextAction = ConsoleKey.DownArrow;
        public static readonly ConsoleKey PrevAction = ConsoleKey.UpArrow;
        public static readonly ConsoleKey NextPage = ConsoleKey.RightArrow;
        public static readonly ConsoleKey PrevPage = ConsoleKey.LeftArrow;
        public static readonly ConsoleKey Exit = ConsoleKey.Escape;

        public static readonly ConsoleKey StopInput = ConsoleKey.K; //used with "ctrl"
        public static readonly ConsoleKey BackSpace = ConsoleKey.Backspace;
    }
}
