using Adapters.Controllers;
using Adapters.Controllers.Console;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DataBase;
using HotelControlSystem.DataBase.Repository;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.DTO;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsoleDb;Trusted_Connection=True;");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

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
