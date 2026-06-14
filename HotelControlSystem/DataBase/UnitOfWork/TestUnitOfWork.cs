using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using UseCase.Database;

namespace HotelControlSystem.DataBase.UnitOfWork
{
    internal class TestUnitOfWork(IUserRepository userRepository) : IUnitOfWork
    {
        public IUserRepository Users => userRepository;

        public IRepository<Room> Rooms => throw new NotImplementedException();

        public IRepository<LoyaltyProgram> LoyaltyPrograms => throw new NotImplementedException();

        public IRepository<Hotel> Hotels => throw new NotImplementedException();

        public IRepository<Booking> Bookings => throw new NotImplementedException();

        public void Commit()
        {
            Console.WriteLine("commit ok");
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void StartTransaction()
        {
            Console.WriteLine("start transaction ok");
        }
    }
}
