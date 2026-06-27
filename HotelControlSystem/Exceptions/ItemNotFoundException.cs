using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    internal class ItemNotFoundException : Exception
    {
        public override string Message { get; }
        public ItemNotFoundException(string? message) 
        {
            Message = message ?? string.Empty;
        }
    }
}
