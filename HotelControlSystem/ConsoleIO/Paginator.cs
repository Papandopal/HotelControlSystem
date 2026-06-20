using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.ConsoleIO
{
    public class Paginator<T> where T : class
    {
        List<List<T>> pages = new();

        int prevCursorPositionLine = Console.CursorTop;
        int index = 0;
        bool exit = false;

        public Paginator() { }
        public void SetItems(List<T> items, uint size = 2)
        {
            exit = false;
            index = 0;
            pages.Clear();

            if (size == 0) throw new ArgumentOutOfRangeException("size of page can`t be 0");

            List<T> page = new() { items[0] };
            for (int i = 1; i < items.Count; i++)
            {
                page.Add(items[i]);
                if (size == 1 || i % (size - 1) == 0)
                {
                    pages.Add(page);
                    page = new();
                }
            }

            if (page.Count > 0) pages.Add(page);

            int beforePrint = Console.CursorTop;

            int lenghtOfItem = pages[0][0].ToString()?.Split('\n').Length ?? 1;

            int expectedCursorTop = beforePrint + (int)size*lenghtOfItem;
            int actualCursorTop = Console.CursorTop;

            int scrollShift = expectedCursorTop - actualCursorTop;

            prevCursorPositionLine = beforePrint - scrollShift;
        }

        public bool TryGetPage(int num)
        {
            if (num >= pages.Count || num < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ConsoleClear()
        {
            int currentCursor = Console.CursorTop;

            for (int i = prevCursorPositionLine; i < currentCursor; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }
            Console.SetCursorPosition(0, prevCursorPositionLine);
        }

        private void WriteEnumirable(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void StartPagination()
        {
            CurPage();

            while (!exit)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                Action choise = input switch
                {
                    ConsoleKeyInfo key when key.Key == Symbols.NextPage => NextPage,
                    ConsoleKeyInfo key when key.Key == Symbols.PrevPage => PrevPage,
                    ConsoleKeyInfo key when key.Key == Symbols.Exit => Exit,
                    _ => StartPagination
                };
                choise.Invoke();
            }

        }

        private void CurPage()
        {
            ConsoleClear();
            if (!TryGetPage(0)) exit = true;
            else WriteEnumirable(pages[index]);
        }

        private void NextPage()
        {
            ConsoleClear();
            if (TryGetPage(++index)) WriteEnumirable(pages[index]);
            else WriteEnumirable(pages[--index]);
        }

        private void PrevPage()
        {
            ConsoleClear();
            if (TryGetPage(--index)) WriteEnumirable(pages[index]);
            else WriteEnumirable(pages[++index]);
        }

        private void Exit()
        {
            exit = true;
        }
    }
}
