using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.Services.Authorisation
{
    internal interface IAuthorisationService
    {
        User Verify(string username, string password);
        void Registration();
    }
}
