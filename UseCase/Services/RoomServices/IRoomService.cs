using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;
using UseCase.DTOs.HotelDTOs;
using UseCase.DTOs.RoomDTOs;

namespace UseCase.Services.RoomServices
{
    public interface IRoomService
    {
        public bool IsExists(int roomId);
        public void Create(CreateRoomUseCaseDTO createHotelUseCaseDTO);
        public void Update(UpdateRoomUseCaseDTO updateRoomUseCaseDTO);
        public void Delete(int id);
        public List<RoomInfoUseCaseDTO> GetAllRooms();
        public List<RoomInfoUseCaseDTO> GetRoomsByType(RoomType type);
        public List<RoomInfoUseCaseDTO> GetRoomsByCapacity(int capacity);
        public List<RoomInfoUseCaseDTO> GetRoomsByPriceRange(double min_price = 0, double max_price = double.MaxValue);
        public List<RoomInfoUseCaseDTO> GetRoomsByDate(DateTime date);
        public List<RoomInfoUseCaseDTO> GetSortedRoomsByPrice();
        public List<RoomInfoUseCaseDTO> GetSortedRoomsByCapacity();
    }
}
