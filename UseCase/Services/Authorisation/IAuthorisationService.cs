using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using UseCase.DTO;

namespace UseCase.Services.Authorisation
{
    public interface IAuthorisationService
    {
        public AuthorisedUserDTO Verify(VerifyUserDTO info);
        public AuthorisedUserDTO Registration(RegistrateUserUseCaseDTO info);
    }
}
