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
    internal class BookingRepository(AppDbContext context) : IBookingRepository
    {
        DbSet<Booking> bookings = context.Set<Booking>();
        public void Add(Booking entity)
        {
            bookings.Add(entity);
        }

        public void Delete(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == id);
            if (booking is null) throw new ItemNotFoundException("booking not found");
            booking.IsDeleted = true;
        }

        public List<Booking> GetAll()
        {
            return bookings.ToList();
        }

        public Booking GetById(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == id);
            if (booking is null) throw new ItemNotFoundException("booking not found");
            return booking;
        }

        public void Update(Booking entity)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == entity.Id);
            if (booking is null) throw new ItemNotFoundException("booking not found");
            booking = entity;
        }
    }
}
