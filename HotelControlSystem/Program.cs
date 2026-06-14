using Adapters.Controllers;
using Adapters.Controllers.Console;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DataBase.Repository;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.DTO;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Database;
using UseCase.Services.Authorisation;

namespace HotelControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<Dialog>();
            services.AddScoped<Controller>();
            services.AddLogging();

            services.AddScoped<IUnitOfWork, TestUnitOfWork>();
            services.AddScoped<IUserRepository, TestUserRepository>();

            services.AddScoped<IAuthorisationService, AuthorisationService>();

            services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile<Mapper>();
            });
            services.AddScoped<UserMainInfoDTO>();

            var provider = services.BuildServiceProvider();
            
            var dialog = provider.GetService<Dialog>();
            if(dialog is null) Console.WriteLine("мамой клянусь, такого быть не может");
            else dialog.Start();
        }
    }
}
