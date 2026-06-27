using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    internal class AccessDeniedException: Exception
    {
        public override string Message { get; }
        public AccessDeniedException(string? message) 
        {
            Message = message ?? string.Empty;
        }
    }
}
