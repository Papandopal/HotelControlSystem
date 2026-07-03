using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    internal class UnsuitableItemException : Exception
    {
        public override string Message { get; }
        public UnsuitableItemException(string? message)
        {
            Message = message ?? string.Empty;
        }
    }
}
