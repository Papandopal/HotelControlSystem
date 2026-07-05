using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public IEnumerable<Booking> GetBookingsByRoomId(int roomId);
        public IEnumerable<Booking> GetBookingsByUserId(int userId);
    }
}
