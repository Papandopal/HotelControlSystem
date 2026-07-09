using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.Services.AuthorisationServices;

namespace Adapters.Controllers.Console
{
    public class AuthorisationController(IAuthorisationService authorisation, IMapper mapper)
    {
        public void Registration(RegistrateUserDTO registarteUserDTO)
        {
            var registrationUserDTO = mapper.Map<RegistrateUserUseCaseDTO>(registarteUserDTO);
            authorisation.Registration(registrationUserDTO);
        }

        public void Authorisation(VerifyUserDTO verifyUserDTO)
        {
            var verufyUserUseCaseDTO = mapper.Map<VerifyUserUseCaseDTO>(verifyUserDTO);
            authorisation.Verify(verufyUserUseCaseDTO);
        }
    }
}
