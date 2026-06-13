using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase;

namespace HotelControlSystem.DataBase.Repository
{
    public class HotelRepository(DbContext context) : IRepository<Hotel>
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

        public Hotel? GetById(int id)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == id);
            if (hotel is null) throw new ItemNotFoundException("hotel not found");
            return hotel;
        }

        public void Update(Hotel entity)
        {
            var hotel = hotels.FirstOrDefault(x => x.Id == entity.Id);
            if (hotel is null) throw new ItemNotFoundException("hotel not found");
            hotel = entity;
        }
    }
}
