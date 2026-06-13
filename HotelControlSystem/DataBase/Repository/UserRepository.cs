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
    internal class UserRepository(DbContext context) : IRepository<User>
    {
        DbSet<User> users = context.Set<User>();
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
