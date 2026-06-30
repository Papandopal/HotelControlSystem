using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using UseCase.DTOs.AuthorisationDTOs;

namespace UseCase.Services.AuthorisationServices
{
    public interface IAuthorisationService
    {
        public AuthorisedUserUseCaseDTO Verify(VerifyUserUseCaseDTO info);
        public AuthorisedUserUseCaseDTO Registration(RegistrateUserUseCaseDTO info);
    }
}
