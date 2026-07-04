using Adapters.Controllers.Console;
using FluentValidation;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DataBase;
using HotelControlSystem.DataBase.Repository;
using HotelControlSystem.DataBase.UnitOfWork;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.RoleBehavior;
using HotelControlSystem.Services.AuthorisationServices;
using HotelControlSystem.Services.HotelServices;
using HotelControlSystem.Services.UserServices;
using HotelControlSystem.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Database;
using UseCase.Database.Repositories;
using UseCase.Services.AuthorisationServices;
using UseCase.Services.HotelServices;
using UseCase.Services.UserServices;

namespace HotelControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var services = new ServiceCollection();

            services.AddScoped<Dialog>();

            services.AddScoped<GeneralBehavior>();
            services.AddScoped<CustomerBehavior>();
            services.AddScoped<AdminBehavior>();
            services.AddScoped<ManagerBehavior>();

            services.AddScoped<AuthorisationController>();
            services.AddScoped<UserController>();
            services.AddScoped<RoomController>();
            services.AddScoped<BookingController>();
            services.AddScoped<HotelController>();
            services.AddScoped<LoyaltyProgramController>();

            services.AddLogging();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsoleDb1;Trusted_Connection=True;");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ILoyaltyProgramRepository, LoyaltyProgramRepository>();

            services.AddScoped<IAuthorisationService, AuthorisationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHotelService, HotelService>();

            services.AddValidatorsFromAssemblyContaining<HotelValidator>();

            services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile<Mapper>();
            });
            services.AddScoped(typeof(Paginator<>));

            services.AddScoped<UserMainInfoDTO>();

            var provider = services.BuildServiceProvider();

            var dialog = provider.GetService<Dialog>();
            if (dialog is null) Console.WriteLine("");
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
