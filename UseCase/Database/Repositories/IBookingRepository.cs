using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public IEnumerable<Booking> GetBookingsByRoomId(int roomId);
        public IEnumerable<Booking> GetBookingsByUserId(int userId);
        public IEnumerable<Booking> GetBookingsByManagerId(int managerId);
    }
}
