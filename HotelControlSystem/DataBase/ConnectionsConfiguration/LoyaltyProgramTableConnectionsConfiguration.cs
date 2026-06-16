using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelControlSystem.DataBase.ConnectionsConfiguration
{
    internal class LoyaltyProgramTableConnectionsConfiguration : IEntityTypeConfiguration<LoyaltyProgram>
    {
        public void Configure(EntityTypeBuilder<LoyaltyProgram> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.User).WithOne().HasForeignKey<LoyaltyProgram>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
