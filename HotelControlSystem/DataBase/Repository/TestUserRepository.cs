using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using UseCase.Database;

namespace HotelControlSystem.DataBase.Repository
{
    internal class TestUserRepository : IUserRepository
    {
        List<User> _users = new List<User>();
        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public void Delete(int id)
        {
            _users.Remove(GetById(id));
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }

        public void Update(User entity)
        {
            _users[_users.IndexOf(entity)] = entity;
        }
    }
}
