using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        public IEnumerable<Hotel> GetHotelsByCity(string city);
    }
}
