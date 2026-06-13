using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers;
using HotelControlSystem.DTO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HotelControlSystem.ConsoleIO
{
    internal class Dialog(UserMainInfoDTO userMainInfo, IController identifire)
    {
        UserMainInfoDTO userMainInfo = userMainInfo;
        IController identifire = identifire;
        int chouse;
        public void Start()
        {
            while (true)
            {

                try
                {
                    if (userMainInfo.Name.Length != 0) Console.WriteLine(userMainInfo.ToString());
                    else Console.WriteLine("Unauthorised");

                    Console.WriteLine("1 - Registration");
                    Console.WriteLine("2 - Log in");
                    Console.WriteLine("3 - Log out");
                    Console.WriteLine("4 - Exit");


                    if (!int.TryParse(Console.ReadLine(), out chouse)) continue;
                    RunCommand(chouse);
                }
                catch 
                {

                }

                
            }
        }

        public void RunCommand(int commandId)
        {
            switch (commandId)
            {
                case 1:

                default:
                    break;
            }
        }
    }
}
