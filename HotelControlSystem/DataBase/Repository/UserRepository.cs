using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase.Database;

namespace HotelControlSystem.DataBase.Repository
{
    internal class UserRepository(DbContext context) : IUserRepository
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

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetByUserName(string userName)
        {
            var user = users.FirstOrDefault(x => x.UserName == userName);
            if (user is null) throw new ItemNotFoundException("user not found");
            return user;
        }
    }
}
