using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelControlSystem.Exceptions;

namespace HotelControlSystem.ConsoleIO
{
    internal static class Output
    {
        private static int prevCursorTop = Console.CursorTop;
        private static int GetCursorTop(object item, int cursorTopBeforePrint) 
        {
            int lenghtOfItem = item.ToString()?.Split('\n').Length ?? 1;

            int expectedCursorTop = cursorTopBeforePrint + lenghtOfItem;
            int actualCursorTop = Console.CursorTop;

            int scrollShift = expectedCursorTop - actualCursorTop;

            return cursorTopBeforePrint - scrollShift;
        }
        private static int GetCursorTop(IEnumerable<object> items, int cursorTopBeforePrint)
        {

            if (items.Count() == 0) 
            {
                return 0;
            }

            int lenghtOfItem = items.ElementAt(0).ToString()?.Split('\n').Length ?? 1;

            int expectedCursorTop = cursorTopBeforePrint + lenghtOfItem*items.Count();
            int actualCursorTop = Console.CursorTop;

            int scrollShift = expectedCursorTop - actualCursorTop;

            return cursorTopBeforePrint - scrollShift;
        }
        public static void Write(object item)
        {
            int beforePrint = Console.CursorTop;
            Console.Write(item);
            prevCursorTop = GetCursorTop(item, beforePrint);
        }
        public static void WriteLine(object item)
        {
            int beforePrint = Console.CursorTop;
            Console.WriteLine(item);
            prevCursorTop = GetCursorTop(item, beforePrint);
        }
        public static void WriteList(IEnumerable<object> items)
        {
            int beforePrint = Console.CursorTop;
            foreach (object item in items)
            {
                Console.WriteLine(item);
            }
            prevCursorTop = GetCursorTop(items, beforePrint);
        }
        public static void ConsoleClear()
        {
            int currentCursor = Console.CursorTop;

            for (int i = prevCursorTop; i < currentCursor; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }
            Console.SetCursorPosition(0, prevCursorTop);
        }
    }
}
