using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using UseCase.DTO;

namespace UseCase.Services.Authorisation
{
    internal interface IAuthorisationService
    {
        AuthorisedUser Verify(VerifyUserDTO info);
        AuthorisedUser Registration(RegistrationUserDTO info);
    }
}
