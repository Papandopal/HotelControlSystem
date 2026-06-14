using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase.Database;

namespace HotelControlSystem.DataBase.Repository
{
    internal class RoomRepository(AppDbContext context) : IRepository<Room>
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

        public Room GetById(int id)
        {
            var room = rooms.FirstOrDefault(x => x.Id == id);
            if (room is null) throw new ItemNotFoundException("room not found");
            return room;
        }

        public void Update(Room entity)
        {
            var room = rooms.FirstOrDefault(x => x.Id == entity.Id);
            if (room is null) throw new ItemNotFoundException("room not found");
            room = entity;
        }
    }
}
