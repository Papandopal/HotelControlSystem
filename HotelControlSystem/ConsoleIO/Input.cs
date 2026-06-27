using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HotelControlSystem.Exceptions;

namespace HotelControlSystem.ConsoleIO
{
    internal static class Input
    {
        public static void GetItem<T>(string text, out T result) where T : IParsable<T>
        {
            Output.Write(text);

            string? input = Console.ReadLine();

            while (input is null || input == string.Empty || !T.TryParse(input, null, out result))
            {
                Output.WriteLine("Invalide data");
                input = Console.ReadLine();
            }
        }

        private static string BuildInput()
        {
            StringBuilder builder = new();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

                if (key.Key == Symbols.StopInput && key.Modifiers.HasFlag(ConsoleModifiers.Control))
                    throw new UserCancelledInputException("user cancelled input");

                builder.Append(key);

            } while (key.Key != ConsoleKey.Enter);

            return builder.ToString();
        }

    }
}

