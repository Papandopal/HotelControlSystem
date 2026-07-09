using Microsoft.EntityFrameworkCore.Storage;
using UseCase.Database;
using UseCase.Database.Repositories;

namespace HotelControlSystem.DataBase.UnitOfWork
{
    internal class UnitOfWork(AppDbContext dbContext, IUserRepository userRepository, IRoomRepository roomRepository,
        IHotelRepository hotelRepository, ILoyaltyProgramRepository loyaltyProgramRepository, 
        IBookingRepository bookingRepository) : IUnitOfWork
    {
        IDbContextTransaction? transaction;
        public IUserRepository Users => userRepository;
        public IRoomRepository Rooms => roomRepository;
        public ILoyaltyProgramRepository LoyaltyPrograms =>  loyaltyProgramRepository;
        public IHotelRepository Hotels => hotelRepository;
        public IBookingRepository Bookings => bookingRepository;

        public void StartTransaction()
        {
            if(transaction is not null) Rollback();
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
