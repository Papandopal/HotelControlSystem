using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    public class UnknowRoleException: Exception
    {
        public UnknowRoleException(string? message)
        {
            Message = message ?? string.Empty;
        }
        public override string Message { get; }
    }
}
