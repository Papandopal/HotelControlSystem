using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        public IEnumerable<Room> GetRoomsByPriceRange(decimal min_price = 0, decimal max_price = decimal.MaxValue);
    }
}
