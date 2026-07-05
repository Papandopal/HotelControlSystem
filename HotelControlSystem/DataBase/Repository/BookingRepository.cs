using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

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

        public IEnumerable<Booking> GetBookingsByRoomId(int roomId)
        {
            return bookings.Where(x=>x.RoomId == roomId);
        }

        public IEnumerable<Booking> GetBookingsByUserId(int userId)
        {
            return bookings.Where((x)=>x.UserId == userId);
        }

        public Booking GetById(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == id);
            if (booking is null) throw new ItemNotFoundException("booking not found");
            return booking;
        }

        public bool IsExists(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == id);
            return booking is not null && !booking.IsDeleted;
        }

        public void Update(Booking entity)
        {
            var booking = bookings.FirstOrDefault(x => x.Id == entity.Id);
            if (booking is null) throw new ItemNotFoundException("booking not found");
            bookings.Update(booking);
        }
    }
}
