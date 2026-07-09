using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

namespace HotelControlSystem.DataBase.Repository
{
    internal class RoomRepository(AppDbContext context) : IRoomRepository
    {
        DbSet<Room> rooms = context.Set<Room>();
        public void Add(Room entity)
        {
            rooms.Add(entity);
        }

        public void Delete(int id)
        {
            var room = rooms.FirstOrDefault(x => x.Id == id);
            if (room is null) throw new ItemNotFoundException("room not found");
            room.IsDeleted = true;
        }

        public List<Room> GetAll()
        {
            return rooms.ToList();
        }

        public Room GetById(int id)
        {
            var room = rooms.FirstOrDefault(x => x.Id == id);
            if (room is null) throw new ItemNotFoundException("room not found");
            return room;
        }

        public IEnumerable<Room> GetRoomsByPriceRange(decimal min_price = 0, decimal max_price = decimal.MaxValue)
        {
            return rooms.Where(x => x.PricePerNight >= min_price && x.PricePerNight <= max_price);
        }

        public bool IsExists(int id)
        {
            var room = rooms.FirstOrDefault(x => x.Id == id);
            return room is not null && !room.IsDeleted;
        }

        public void Update(Room entity)
        {
            var room = rooms.FirstOrDefault(x => x.Id == entity.Id);
            if (room is null) throw new ItemNotFoundException("room not found");
            rooms.Update(room);
        }
    }
}
