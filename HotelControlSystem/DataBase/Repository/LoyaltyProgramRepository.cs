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
    internal class LoyaltyProgramRepository(AppDbContext context) : IRepository<LoyaltyProgram>
    {
        DbSet<LoyaltyProgram> loyaltyPrograms = context.Set<LoyaltyProgram>();
        public void Add(LoyaltyProgram entity)
        {
            loyaltyPrograms.Add(entity);
        }

        public void Delete(int id)
        {
            var loyaltyProgram = loyaltyPrograms.FirstOrDefault(x => x.Id == id);
            if (loyaltyProgram is null) throw new ItemNotFoundException("loyaltyProgram not found");
            loyaltyProgram.IsDeleted = true;
        }

        public LoyaltyProgram GetById(int id)
        {
            var loyaltyProgram = loyaltyPrograms.FirstOrDefault(x => x.Id == id);
            if (loyaltyProgram is null) throw new ItemNotFoundException("loyaltyProgram not found");
            return loyaltyProgram;
        }

        public void Update(LoyaltyProgram entity)
        {
            var loyaltyProgram = loyaltyPrograms.FirstOrDefault(x => x.Id == entity.Id);
            if (loyaltyProgram is null) throw new ItemNotFoundException("loyaltyProgram not found");
            loyaltyProgram = entity;
        }
    }
}
