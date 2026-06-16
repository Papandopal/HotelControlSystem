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
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var services = new ServiceCollection();

            services.AddScoped<Dialog>();
            services.AddScoped<UserController>();
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
            if(dialog is null) Console.WriteLine("");
            else dialog.Start();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

#if DEBUG
            return;
#endif

            var exception = (Exception)e.ExceptionObject;
            if (exception is not null)
            {
                Console.WriteLine(exception.Message);
            
                Environment.Exit(exception.HResult);
            }
            else
            {
                Console.WriteLine("Unknow error");
                Environment.Exit(-1);
            }
            
            
        }
    }
}
