using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Exceptions
{
    internal class AuthorisationFailedException : Exception
    {
        public AuthorisationFailedException(string? message)
        {
            if (message is not null) Message = message;
        }
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return Message;
        }
    }
}
