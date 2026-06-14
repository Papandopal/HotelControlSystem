using Adapters.Controllers;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DataBase.Repository;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.DTO;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Database;

namespace HotelControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<UserMainInfoDTO>();
            services.AddScoped<Dialog>();
            services.AddScoped<IController, Controller>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            var provider = services.BuildServiceProvider();
            
            var dialog = provider.GetService<Dialog>();
            if(dialog is null) Console.WriteLine("мамой клянусь, такого быть не может");
            else dialog.Start();
        }
    }
}
