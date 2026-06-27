using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.ConsoleIO
{
    public class Paginator<T> where T : class
    {
        private List<List<T>> pages = new();

        private int index = 0;
        private bool exit = false;

        public Paginator() { }

        public void SetItems(List<T> items, uint size = 2)
        {
            exit = false;
            index = 0;
            pages.Clear();

            if (size == 0) throw new ArgumentOutOfRangeException("size of page can`t be 0");

            List<T> page = new();
            int curCount = 0;

            foreach (T item in items)
            {
                page.Add(item);
                curCount++;
                if(curCount == size)
                {
                    pages.Add(page);
                    page = new();
                    curCount = 0;
                }
            }

            if (page.Count > 0) pages.Add(page);
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
            Output.ConsoleClear();
            if (!TryGetPage(0)) exit = true;
            else Output.WriteList(pages[index]);
        }

        private void NextPage()
        {
            Output.ConsoleClear();
            if (TryGetPage(++index)) Output.WriteList(pages[index]);
            else Output.WriteList(pages[--index]);
        }

        private void PrevPage()
        {
            Output.ConsoleClear();
            if (TryGetPage(--index)) Output.WriteList(pages[index]);
            else Output.WriteList(pages[++index]);
        }

        private void Exit()
        {
            exit = true;
        }
    }
}
