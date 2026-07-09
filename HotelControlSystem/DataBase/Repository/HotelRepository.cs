using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

namespace HotelControlSystem.DataBase.Repository
{
    public class HotelRepository(AppDbContext context) : IHotelRepository
    {
        DbSet<Hotel> hotels = context.Set<Hotel>();
        public void Add(Hotel entity)
        {
            hotels.Add(entity);
        }

        public void Delete(int id)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == id);
            if (hotel is null) throw new ItemNotFoundException("hotel not found");
            hotel.IsDeleted = true;
        }

        public List<Hotel> GetAll()
        {
            return hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == id);
            if (hotel is null) throw new ItemNotFoundException("hotel not found");
            return hotel;
        }

        public IEnumerable<Hotel> GetHotelsByCity(string city)
        {
            return hotels.Where(x => x.City == city);
        }

        public bool IsExists(int id)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == id);
            return hotel is not null && !hotel.IsDeleted;
        }

        public void Update(Hotel entity)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == entity.Id);
            if (hotel is null) throw new ItemNotFoundException("hotel not found");
            hotels.Update(hotel);
        }
    }
}
