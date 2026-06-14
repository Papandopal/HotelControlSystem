using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Database
{
    public interface IUnitOfWork
    {
        public void StartTransaction();
        public void Commit();
        public void Rollback();
        public IUserRepository Users { get; }
        public IRepository<Room> Rooms { get; }
        public IRepository<LoyaltyProgram> LoyaltyPrograms { get; }
        public IRepository<Hotel> Hotels { get; }
        public IRepository<Booking> Bookings { get; }
    }
}
