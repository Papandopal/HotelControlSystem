using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using Microsoft.EntityFrameworkCore;
using UseCase;

namespace HotelControlSystem.DataBase.Repository
{
    internal class RoomRepository(DbContext context) : IRepository<Room>
    {
        DbSet<Room> rooms = context.Set<Room>();
        public void Add(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Room? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
