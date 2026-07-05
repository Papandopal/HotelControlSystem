using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTOs.RoomDTOs;
using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using UseCase.Database;
using UseCase.DTOs.RoomDTOs;
using UseCase.Services.RoomServices;

namespace Adapters.Controllers.Console
{
    public class RoomController(IRoomService roomService, IMapper mapper)
    {
        public void Create(CreateRoomDTO createRoomDTO)
        {
            roomService.Create(mapper.Map<CreateRoomUseCaseDTO>(createRoomDTO));
        }

        public void Update(UpdateRoomDTO updateRoomDTO)
        {
            roomService.Update(mapper.Map<UpdateRoomUseCaseDTO>(updateRoomDTO));
        }

        public void Delete(int id)
        {
            roomService.Delete(id);
        }

        public List<RoomInfoDTO> GetAllRooms()
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetAllRooms());
        }

        public List<RoomInfoDTO> GetRoomsByHotelId(int hotelId)
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetRoomsByHotelId(hotelId));
        }

        public List<RoomInfoDTO> GetRoomsByCapacity(int capacity)
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetRoomsByCapacity(capacity));

        }

        public List<RoomInfoDTO> GetRoomsByDate(DateTime date)
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetRoomsByDate(date));
        }

        public List<RoomInfoDTO> GetRoomsByPriceRange(decimal min_price = 0, decimal max_price = decimal.MaxValue)
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetRoomsByPriceRange(min_price, max_price));
        }

        public List<RoomInfoDTO> GetRoomsByType(RoomType type)
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetRoomsByType(type));
        }

        public List<RoomInfoDTO> GetSortedRoomsByCapacity()
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetSortedRoomsByCapacity());
        }

        public List<RoomInfoDTO> GetDescSortedRoomsByCapacity()
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetDescSortedRoomsByCapacity());
        }

        public List<RoomInfoDTO> GetSortedRoomsByPrice()
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetSortedRoomsByPrice());
        }
        public List<RoomInfoDTO> GetDescSortedRoomsByPrice()
        {
            return mapper.Map<List<RoomInfoDTO>>(roomService.GetDescSortedRoomsByPrice());
        }

        public bool IsExists(int roomId)
        {
            return roomService.IsExists(roomId);
        }
    }
}
