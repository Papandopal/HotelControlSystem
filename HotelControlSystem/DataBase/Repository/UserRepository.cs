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
    internal class UserRepository(AppDbContext context) : IUserRepository
    {
        DbSet<User> users = context.Set<User>();
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user is null) throw new ItemNotFoundException("user not found");
            user.isDeleted = true;
        }

        public User GetById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user is null) throw new ItemNotFoundException("user not found");
            return user;
        }

        public void Update(User entity)
        {
            var user = users.FirstOrDefault(x => x.Id == entity.Id);
            if (user is null) throw new ItemNotFoundException("user not found");
            user = entity;
        }

        public IEnumerable<User> GetByUserName(string userName)
        {
            var user = users.Where(x => x.UserName == userName).AsEnumerable();
            if (user.Count()==0) throw new ItemNotFoundException("user not found");
            return user;
        }

        public List<User> GetAll()
        {
            return users.ToList();
        }
    }
}
