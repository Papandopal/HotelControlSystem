using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

namespace UseCase.Database
{
    public interface IUnitOfWork
    {
        public void StartTransaction();
        public void Commit();
        public void Rollback();
        public IUserRepository Users { get; }
        public IRoomRepository Rooms { get; }
        public ILoyaltyProgramRepository LoyaltyPrograms { get; }
        public IHotelRepository Hotels { get; }
        public IBookingRepository Bookings { get; }
    }
}
