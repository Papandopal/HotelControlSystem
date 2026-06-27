using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    internal class AuthorisationFailedException : Exception
    {
        public override string Message { get; }
        public AuthorisationFailedException(string? message)
        {
            Message = message ?? string.Empty;
        }
    }
}
