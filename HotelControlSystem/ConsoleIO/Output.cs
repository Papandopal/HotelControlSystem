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
        private static int GetCursorTop<T>(T item, int cursorTopBeforePrint) 
        {
            if (item is null)
            {
                return prevCursorTop;
            }
            int lenghtOfItem = item.ToString()?.Split('\n').Length ?? 1;

            int expectedCursorTop = cursorTopBeforePrint + lenghtOfItem;
            int actualCursorTop = Console.CursorTop;

            int scrollShift = expectedCursorTop - actualCursorTop;

            return cursorTopBeforePrint - scrollShift;
        }
        private static int GetCursorTop<T>(IEnumerable<T> items, int cursorTopBeforePrint)
        {

            if (items is null || items.Count() == 0) 
            {
                return prevCursorTop;
            }

            int lenghtOfItem = items.ElementAt(0)?.ToString()?.Split('\n').Length ?? 1;

            int expectedCursorTop = cursorTopBeforePrint + lenghtOfItem*items.Count();
            int actualCursorTop = Console.CursorTop;

            int scrollShift = expectedCursorTop - actualCursorTop;

            return cursorTopBeforePrint - scrollShift;
        }
        public static void Write<T>(T item)
        {
            int beforePrint = Console.CursorTop;
            Console.Write(item);
            prevCursorTop = GetCursorTop(item, beforePrint);
        }
        public static void WriteLine<T>(T item)
        {
            int beforePrint = Console.CursorTop;
            Console.WriteLine(item);
            prevCursorTop = GetCursorTop(item, beforePrint);
        }
        public static void WriteList<T>(IEnumerable<T> items)
        {
            if(items is null || items.Count() == 0)
            {
                return;
            }

            int beforePrint = Console.CursorTop;
            foreach (T item in items)
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
