using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelControlSystem.ConsoleIO
{
    public static class Symbols
    {
        public static readonly string SelectedItem = "-> ";

        public static readonly ConsoleKey RunAction = ConsoleKey.Enter;
        public static readonly ConsoleKey NextAction = ConsoleKey.DownArrow;
        public static readonly ConsoleKey PrevAction = ConsoleKey.UpArrow;
        public static readonly ConsoleKey Exit = ConsoleKey.Escape;
    }
}
