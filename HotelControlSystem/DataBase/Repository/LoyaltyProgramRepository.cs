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
    internal class LoyaltyProgramRepository(DbContext context) : IRepository<LoyaltyProgram>
    {
        DbSet<LoyaltyProgram> loyaltyPrograms = context.Set<LoyaltyProgram>();
        public void Add(LoyaltyProgram entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LoyaltyProgram? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(LoyaltyProgram entity)
        {
            throw new NotImplementedException();
        }
    }
}
