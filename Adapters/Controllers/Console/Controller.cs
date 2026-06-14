using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTO;
using AutoMapper;
using UseCase.DTO;
using UseCase.Services.Authorisation;

namespace Adapters.Controllers.Console
{
    public class Controller(IAuthorisationService authorisation, IMapper mapper)
    {
        public ConsoleUserDTO Registration(RegistrateUserDTO registarteUserDTO)
        {
            var registrationUserDTO = mapper.Map<RegistrateUserUseCaseDTO>(registarteUserDTO);
            AuthorisedUserDTO authorisedUserDTO = authorisation.Registration(registrationUserDTO);
            return mapper.Map<ConsoleUserDTO>(authorisedUserDTO);
        }
    }
}
