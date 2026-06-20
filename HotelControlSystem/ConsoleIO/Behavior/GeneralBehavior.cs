using Adapters.Controllers.Console;
using Adapters.DTO;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.DTO;

namespace HotelControlSystem.ConsoleIO.Behavior
{
    internal class GeneralBehavior
    {
        public List<Action> Actions { get; } = new List<Action>();

        UserMainInfoDTO userMainInfoDTO;
        UserController userController;
        IMapper mapper;

        public GeneralBehavior(UserMainInfoDTO userMainInfoDTO, IMapper mapper, UserController userController)
        {
            this.userMainInfoDTO = userMainInfoDTO;
            this.userController = userController;
            this.mapper = mapper;

            Actions.AddRange(Registration, Verify, LogOut);
        }

        private static void Input<T>(string text, out T result) where T : IParsable<T>
        {
            Console.Write(text);
            string? input = null;
            input = Console.ReadLine();
            while (input is null || input == string.Empty || !T.TryParse(input, null, out result))
            {
                Console.WriteLine("Invalide data");
                input = Console.ReadLine();
            }
        }

        private RegistrateUserConsoleDTO GetRegistrateUserConsoleDTO()
        {
            string name, password, email;
            int role = 0;

            Input("Name: ", out name);
            Input("Password: ", out password);
            Input("Email: ", out email);
            while (role <= 0 || role > (int)UserRole.Admin)Input("Role: ", out role);

            return new RegistrateUserConsoleDTO() { UserName = name, Password = password, Email = email, Role = (UserRole)role };
        }

        private void Registration()
        {
            RegistrateUserConsoleDTO registrateUserConsole = GetRegistrateUserConsoleDTO();
            RegistrateUserDTO registrateUser = mapper.Map<RegistrateUserDTO>(registrateUserConsole);
            AuthorisedUserDTO authorisedUserDTO = userController.Registration(registrateUser);
            mapper.Map(authorisedUserDTO, userMainInfoDTO);
        }

        private VerifyUserConsoleDTO GetVerifyIUserConsoleDTO()
        {
            string name, password;
            Input("Name: ", out name);
            Input("Password: ", out password);
            return new VerifyUserConsoleDTO() { UserName = name, Password = password };
        }

        private void Verify()
        {
            VerifyUserConsoleDTO verifyUserConsole = GetVerifyIUserConsoleDTO();
            VerifyUserDTO verifyUser = mapper.Map<VerifyUserDTO>(verifyUserConsole);
            AuthorisedUserDTO authorisedUser = userController.Authorisation(verifyUser);
            mapper.Map(authorisedUser, userMainInfoDTO);
        } 

        private void LogOut()
        {
            mapper.Map(userMainInfoDTO, new UserMainInfoDTO());
        }
    }
}
