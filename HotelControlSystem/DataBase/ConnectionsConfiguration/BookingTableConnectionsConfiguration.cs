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
            builder.HasOne(x=>x.User).WithMany().HasPrincipalKey(user=>user.Id).HasForeignKey(x=>x.UserId);
            builder.HasOne(x => x.Room).WithMany().HasPrincipalKey(room => room.Id).HasForeignKey(x => x.RoomId);
        }
    }
}
