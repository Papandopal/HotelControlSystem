using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.RoomDTOs;

namespace UseCase.Services.RoomServices
{
    public class RoomService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateRoomUseCaseDTO> createValidator,
        IValidator<UpdateRoomUseCaseDTO> updateValidator) : IRoomService
    {
        private List<RoomInfoUseCaseDTO> roomsCatalog = new();
        public void Create(CreateRoomUseCaseDTO createRoomUseCaseDTO)
        {
            createValidator.ValidateAndThrow(createRoomUseCaseDTO);

            unitOfWork.StartTransaction();

            Hotel hotel = unitOfWork.Hotels.GetById(createRoomUseCaseDTO.HotelId);
            Room new_room = new Room(hotel);

            new_room = mapper.Map<Room>(createRoomUseCaseDTO);

            unitOfWork.Rooms.Add(new_room);

            unitOfWork.Commit();
        }

        public void Update(UpdateRoomUseCaseDTO updateRoomUseCaseDTO)
        {
            updateValidator.ValidateAndThrow(updateRoomUseCaseDTO);

            unitOfWork.StartTransaction();

            var room = unitOfWork.Rooms.GetById(updateRoomUseCaseDTO.Id);
            var updated_room = mapper.Map(updateRoomUseCaseDTO, room);

            unitOfWork.Rooms.Update(updated_room);

            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            unitOfWork.StartTransaction();

            unitOfWork.Rooms.Delete(id);

            unitOfWork.Commit();
        }

        public List<RoomInfoUseCaseDTO> GetAllRooms()
        {
            unitOfWork.StartTransaction();

            roomsCatalog = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll());

            unitOfWork.Commit();

            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByCapacity(int capacity)
        {
            unitOfWork.StartTransaction();

            roomsCatalog = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll().Where(x=>x.Capacity==capacity));

            unitOfWork.Commit();

            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByDate(DateTime date)
        {
            unitOfWork.StartTransaction();

            roomsCatalog.Clear();
            var all_rooms = unitOfWork.Rooms.GetAll();

            int id;
            bool add_room;
            IEnumerable<Booking> related_bookings;

            foreach (var room in all_rooms)
            {
                id = room.Id;
                add_room = true;
                related_bookings = unitOfWork.Bookings.GetBookingsByRoomId(id);

                foreach (var booking in related_bookings)
                {
                    if (booking.CheckInDate <= date && date <= booking.CheckOutDate)
                    {
                        add_room = false;
                        break;
                    }
                }

                if (add_room) roomsCatalog.Add(mapper.Map<RoomInfoUseCaseDTO>(room));
            }

            unitOfWork.Commit();

            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByPriceRange(decimal min_price = 0, decimal max_price = decimal.MaxValue)
        {
            unitOfWork.StartTransaction();

            roomsCatalog = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetRoomsByPriceRange(min_price, max_price));

            unitOfWork.Commit();
            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByType(RoomType type)
        {
            unitOfWork.StartTransaction();

            roomsCatalog = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll().Where(x=>x.RoomType==type));

            unitOfWork.Commit();
            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetSortedRoomsByCapacity()
        {
            if(roomsCatalog.Count == 0) roomsCatalog = GetAllRooms(); 
            return roomsCatalog.OrderByDescending(x => x.Capacity).ToList();
        }

        public List<RoomInfoUseCaseDTO> GetDescSortedRoomsByCapacity()
        {
            roomsCatalog = GetSortedRoomsByCapacity();
            roomsCatalog.Reverse();
            return roomsCatalog;
        }

        public List<RoomInfoUseCaseDTO> GetSortedRoomsByPrice()
        {
            if (roomsCatalog.Count == 0) roomsCatalog = GetAllRooms();
            return roomsCatalog.OrderByDescending(x => x.PricePerNight).ToList();
        }
        public List<RoomInfoUseCaseDTO> GetDescSortedRoomsByPrice()
        {
            roomsCatalog = GetSortedRoomsByPrice();
            roomsCatalog.Reverse();
            return roomsCatalog;
        }

        public bool IsExists(int roomId)
        {
            unitOfWork.StartTransaction();

            var isExists = unitOfWork.Rooms.IsExists(roomId);

            unitOfWork.Commit();

            return isExists;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByHotelId(int hotelId)
        {
            unitOfWork.StartTransaction();

            roomsCatalog = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll().Where(x=>x.HotelId == hotelId).ToList());

            unitOfWork.Commit();

            return roomsCatalog;
        }
    }
}
