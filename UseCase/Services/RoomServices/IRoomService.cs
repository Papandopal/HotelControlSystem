using DoMain.Enums;
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
        public List<RoomInfoUseCaseDTO> GetRoomsByHotelId(int hotelId);
        public List<RoomInfoUseCaseDTO> GetRoomsByType(RoomType type);
        public List<RoomInfoUseCaseDTO> GetRoomsByCapacity(int capacity);
        public List<RoomInfoUseCaseDTO> GetRoomsByPriceRange(decimal min_price = 0, decimal max_price = decimal.MaxValue);
        public List<RoomInfoUseCaseDTO> GetRoomsByDate(DateTime date);
        public List<RoomInfoUseCaseDTO> GetSortedRoomsByPrice();
        public List<RoomInfoUseCaseDTO> GetDescSortedRoomsByPrice();
        public List<RoomInfoUseCaseDTO> GetSortedRoomsByCapacity();
        public List<RoomInfoUseCaseDTO> GetDescSortedRoomsByCapacity();
    }
}
