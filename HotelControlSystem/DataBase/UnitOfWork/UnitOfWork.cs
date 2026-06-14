using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using HotelControlSystem.DataBase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UseCase.Database;

namespace HotelControlSystem.DataBase.UnitOfWork
{
    internal class UnitOfWork(AppDbContext context, IUserRepository userRepository) : IUnitOfWork
    {
        IDbContextTransaction? transaction;
        AppDbContext dbContext = context;
        public IUserRepository Users => userRepository;
        public IRepository<Room> Rooms => new RoomRepository(dbContext);
        public IRepository<LoyaltyProgram> LoyaltyPrograms => new LoyaltyProgramRepository(dbContext);
        public IRepository<Hotel> Hotels => new HotelRepository(dbContext);
        public IRepository<Booking> Bookings => new BookingRepository(dbContext);

        public void StartTransaction()
        {
            transaction = dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction is null) return;
            dbContext.SaveChanges();
            transaction.Commit();
            transaction.Dispose();
            transaction = null;
        }

        public void Rollback()
        {
            if (transaction is null) return;
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }
    }
}
