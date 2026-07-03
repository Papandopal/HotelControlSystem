using Adapters.Controllers.Console;
using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class GeneralBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        UserMainInfoDTO userMainInfoDTO;
        AuthorisationController userController;
        IMapper mapper;

        public GeneralBehavior(UserMainInfoDTO userMainInfoDTO, IMapper mapper, AuthorisationController userController)
        {
            this.userMainInfoDTO = userMainInfoDTO;
            this.userController = userController;
            this.mapper = mapper;

            //MethodNames must be called "***Action"
            Actions.AddRange(RegistrationAction, VerifyAction, LogOutAction);
        }

        private RegistrateUserConsoleDTO GetRegistrateUserConsoleDTO()
        {
            string name, password, email;
            int role = 0;

            Input.GetItem("Name: ", out name);
            Input.GetItem("Password: ", out password);
            Input.GetItem("Email: ", out email);

            while (role <= 0 || role > (int)UserRole.Admin)
            {
                Input.GetItem("Role: ", out role);
            }

            return new RegistrateUserConsoleDTO() { UserName = name, Password = password, Email = email, Role = (UserRole)role };
        }

        private void RegistrationAction()
        {
            RegistrateUserConsoleDTO registrateUserConsole = GetRegistrateUserConsoleDTO();
            RegistrateUserDTO registrateUser = mapper.Map<RegistrateUserDTO>(registrateUserConsole);
            AuthorisedUserDTO authorisedUserDTO = userController.Registration(registrateUser);
            mapper.Map(authorisedUserDTO, userMainInfoDTO);
        }

        private VerifyUserConsoleDTO GetVerifyUserConsoleDTO()
        {
            string name, password;
            Input.GetItem("Name: ", out name);
            Input.GetItem("Password: ", out password);
            return new VerifyUserConsoleDTO() { UserName = name, Password = password };
        }

        private void VerifyAction()
        {
            VerifyUserConsoleDTO verifyUserConsole = GetVerifyUserConsoleDTO();
            VerifyUserDTO verifyUser = mapper.Map<VerifyUserDTO>(verifyUserConsole);
            AuthorisedUserDTO authorisedUser = userController.Authorisation(verifyUser);
            mapper.Map(authorisedUser, userMainInfoDTO);
        } 

        private void LogOutAction()
        {
            userMainInfoDTO.Reset();
        }
    }
}
