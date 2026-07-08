using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.Services.AuthorisationServices;

namespace Adapters.Controllers.Console
{
    public class AuthorisationController(IAuthorisationService authorisation, IMapper mapper)
    {
        public AuthorisedUserDTO Registration(RegistrateUserDTO registarteUserDTO)
        {
            var registrationUserDTO = mapper.Map<RegistrateUserUseCaseDTO>(registarteUserDTO);
            AuthorisedUserUseCaseDTO authorisedUserDTO = authorisation.Registration(registrationUserDTO);
            return mapper.Map<AuthorisedUserDTO>(authorisedUserDTO);
        }

        public AuthorisedUserDTO Authorisation(VerifyUserDTO verifyUserDTO)
        {
            var verufyUserUseCaseDTO = mapper.Map<VerifyUserUseCaseDTO>(verifyUserDTO);
            AuthorisedUserUseCaseDTO authorisedUserDTO = authorisation.Verify(verufyUserUseCaseDTO);
            return mapper.Map<AuthorisedUserDTO>(authorisedUserDTO);
        }
    }
}
