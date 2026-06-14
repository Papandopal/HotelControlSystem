using Adapters.Controllers.Console;
using Adapters.DTO;
using AutoMapper;
using HotelControlSystem.DTO;

namespace HotelControlSystem.ConsoleIO
{
    internal class Dialog(UserMainInfoDTO userMainInfo, Controller controller, IMapper mapper)
    {
        UserMainInfoDTO userMainInfo = userMainInfo;
        Controller controller = controller;
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

        public RegistrateUserDTO GetRegistrationInfo()
        {
            string? name = null, password = null, email = null;
            Console.WriteLine("Name: ");
            while(name is null) name = Console.ReadLine();

            Console.WriteLine("Password: ");
            while(password is null) password = Console.ReadLine();

            Console.WriteLine("Email: ");
            while(email is null) email = Console.ReadLine();

            return new RegistrateUserDTO() {UserName = name, Password = password, Email = email };
        }

        public void RunCommand(int commandId)
        {
            switch (commandId)
            {
                case 1:
                    RegistrateUserDTO info = GetRegistrationInfo();
                    ConsoleUserDTO consoleUserDTO = controller.Registration(info);
                    userMainInfo = mapper.Map<UserMainInfoDTO>(consoleUserDTO);
                    break;
                case 2:
                    
                default:
                    break;
            }
        }
    }
}
