using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.ConsoleIO
{
    internal static class Input
    {
        public static void GetItem<T>(string text, out T result) where T : IParsable<T>
        {
            Console.Write(text);
            string? input = null;
            input = Console.ReadLine();
            while (input is null || input == string.Empty || !T.TryParse(input, null, out result))
            {
                Console.WriteLine("Invalide data");
                input = Console.ReadLine();
            }
        }
    }
}
