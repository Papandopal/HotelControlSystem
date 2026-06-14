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
    internal class UnitOfWork(IUserRepository users) : DbContext, IUnitOfWork
    {
        IDbContextTransaction? transaction;
        public IUserRepository Users => users;
        public IRepository<Room> Rooms => new RoomRepository(this);
        public IRepository<LoyaltyProgram> LoyaltyPrograms => new LoyaltyProgramRepository(this);
        public IRepository<Hotel> Hotels => new HotelRepository(this);
        public IRepository<Booking> Bookings => new BookingRepository(this);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void StartTransaction()
        {
            transaction = Database.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction is null) return;
            SaveChanges();
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
