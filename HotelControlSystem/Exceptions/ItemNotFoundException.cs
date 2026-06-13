using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string? message) 
        {
            if(message is not null) Message = message;
        }
        public string Message { get; set; } = string.Empty;
    }
}
