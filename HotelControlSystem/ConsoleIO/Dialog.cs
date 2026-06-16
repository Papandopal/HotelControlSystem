using Adapters.Controllers.Console;
using Adapters.DTO;
using AutoMapper;
using HotelControlSystem.DTO;

namespace HotelControlSystem.ConsoleIO
{
    internal class Dialog(UserMainInfoDTO userMainInfo, UserController userController, IMapper mapper)
    {
        UserMainInfoDTO userMainInfo = userMainInfo;
        UserController controller = userController;
        int chouse;
        public void Start()
        {
            while (true)
            {

                try
                {
                    Console.WriteLine(GetInfo());

                    Console.WriteLine("1 - Registration");
                    Console.WriteLine("2 - Log in");
                    Console.WriteLine("3 - Log out");
                    Console.WriteLine("4 - Exit");


                    if (!int.TryParse(Console.ReadLine(), out chouse)) continue;
                    RunCommand(chouse);
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public string GetInfo()
        {
            if (userMainInfo.UserName.Length != 0) return userMainInfo.ToString();
            else return "Unauthorised";
        }

        private static void Input<T>(string text, out T result) where T : IParsable<T>
        {
            Console.Write(text);
            string? input = null;
            while(input is null) input = Console.ReadLine();
            while (!T.TryParse(input, null, out result)) Console.WriteLine("Invalide data");
        }

        private RegistrateUserConsoleDTO GetRegistrateUserConsoleDTO()
        {
            string name, password, email;
            
            Input("Name: ", out name);
            Input("Password: ", out password);
            Input("Email: ", out email);

            return new RegistrateUserConsoleDTO() {UserName = name, Password = password, Email = email };
        }

        private VerifyUserConsoleDTO GetVerifyIUserConsoleDTO()
        {
            string name, password;
            Input("Name: ", out name);
            Input("Password: ", out password);
            return new VerifyUserConsoleDTO() { UserName = name, Password = password };
        }

        private void RunCommand(int commandId)
        {
            switch (commandId)
            {
                case 1:
                    RegistrateUserConsoleDTO registrateUserConsole = GetRegistrateUserConsoleDTO();
                    RegistrateUserDTO registrateUser = mapper.Map<RegistrateUserDTO>(registrateUserConsole);
                    AuthorisedUserDTO authorisedUserDTO = controller.Registration(registrateUser);
                    userMainInfo = mapper.Map<UserMainInfoDTO>(authorisedUserDTO);
                    break;
                case 2:
                    VerifyUserConsoleDTO verifyUserConsole = GetVerifyIUserConsoleDTO();
                    VerifyUserDTO verifyUser = mapper.Map<VerifyUserDTO>(verifyUserConsole);
                    AuthorisedUserDTO authorisedUser = controller.Authorisation(verifyUser);
                    userMainInfo = mapper.Map<UserMainInfoDTO>(authorisedUser);
                    break;
                default:
                    break;
            }
        }
    }
}
