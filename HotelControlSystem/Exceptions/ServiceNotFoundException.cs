using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelControlSystem.Exceptions
{
    public class ServiceNotFoundException: Exception
    {
        public ServiceNotFoundException(string? message) 
        {
            Message = message ?? string.Empty;
        }
        public override string Message { get; }
    }
}
