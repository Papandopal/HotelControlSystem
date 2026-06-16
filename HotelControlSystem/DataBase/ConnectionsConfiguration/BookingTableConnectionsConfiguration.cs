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
    internal class BookingTableConnectionsConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.User).WithOne().HasForeignKey<Booking>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Room).WithOne().HasForeignKey<Booking>(x=>x.RoomId).OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
