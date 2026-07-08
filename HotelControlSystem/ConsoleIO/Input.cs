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
            string input = BuildInput(text);

            while (input == string.Empty || !T.TryParse(input, null, out result))
            {
                Output.WriteLine("Invalide data");
                input = BuildInput(text);
            }
        }

        public static void GetEnumItem<T>(string text, out T result) where T : Enum
        {
            string input = BuildInput(text);

            while (input == string.Empty || !int.TryParse(input, out _) || !Enum.IsDefined(typeof(T), int.Parse(input))) 
            {
                Output.WriteLine("Invalide data");
                input = BuildInput(text);
            }
            result = (T)Enum.Parse(typeof(T), input);
        }

        public static bool TryGetItem<T>(string text, out T? result) where T : IParsable<T>
        {
            string input = BuildInput("(not requared) " + text);
            if (input == string.Empty || !T.TryParse(input, null, out result))
            {
                result = default;
                return false;
            }
            return true;
        }

        public static bool TryGetItem<T>(string text, out T? result) where T : struct, IParsable<T>
        {
            string input = BuildInput("(not requared) " + text);
            if (input == string.Empty || !T.TryParse(input, null, out _))
            {
                result = default;
                return false;
            }
            result = T.Parse(input, null);
            return true;
        }

        public static bool TryGetEnumItem<T>(string text, out T? result) where T : struct, Enum
        {
            string input = BuildInput("(not requared) " + text);

            if (input == string.Empty || !int.TryParse(input, out _) || !Enum.IsDefined(typeof(T), int.Parse(input)))
            {
                result= default;
                return false;
            }
            result = (T)Enum.Parse(typeof(T), input);
            return true;
        }

        private static string BuildInput(string text)
        {
            StringBuilder builder = new();
            ConsoleKeyInfo key;
            Output.Write(text);

            do
            {
                key = Console.ReadKey();

                if (key.Key == SpecialKeys.StopInput && key.Modifiers.HasFlag(ConsoleModifiers.Control))
                    throw new UserCancelledInputException("user cancelled input");
                if (key.Key == SpecialKeys.BackSpace)
                {
                    if (Console.CursorLeft >= text.Length)
                    {
                        Console.Write(' ');
                        Console.CursorLeft--;
                        builder.Remove(builder.Length - 1, 1);
                    }
                    else Console.CursorLeft++;
                    continue;
                }

                builder.Append(key.KeyChar);

            } while (key.Key != ConsoleKey.Enter);

            builder.Remove(builder.Length - 1, 1);
            Output.Write(text + builder.ToString() + '\n');

            return builder.ToString();
        }

    }
}

