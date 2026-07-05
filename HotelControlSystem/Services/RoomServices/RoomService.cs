using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers.Console;
using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.HotelDTOs;
using UseCase.DTOs.RoomDTOs;
using UseCase.Services.RoomServices;

namespace HotelControlSystem.Services.RoomServices
{
    internal class RoomService(IUnitOfWork unitOfWork, IMapper mapper) : IRoomService
    {
        private List<RoomInfoUseCaseDTO> rooms;
        public void Create(CreateRoomUseCaseDTO createRoomUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            if (!unitOfWork.Hotels.IsExists(createRoomUseCaseDTO.HotelId))
            {
                unitOfWork.Rollback();
                throw new ItemNotFoundException("Hotel not found");
            }

            Hotel hotel = unitOfWork.Hotels.GetById(createRoomUseCaseDTO.HotelId);
            Room new_room = new Room(hotel);

            new_room = mapper.Map<Room>(createRoomUseCaseDTO);

            unitOfWork.Rooms.Add(new_room);

            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            unitOfWork.StartTransaction();

            if (!unitOfWork.Rooms.IsExists(id))
            {
                unitOfWork.Rollback();
                throw new ItemNotFoundException("room not found");
            }

            unitOfWork.Rooms.Delete(id);

            unitOfWork.Commit();
        }

        public List<RoomInfoUseCaseDTO> GetAllRooms()
        {
            unitOfWork.StartTransaction();

            rooms = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll());

            unitOfWork.Commit();

            return rooms;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByCapacity(int capacity)
        {
            unitOfWork.StartTransaction();

            rooms = mapper.Map<List<RoomInfoUseCaseDTO>>(unitOfWork.Rooms.GetAll().Where(x=>x.Capacity==capacity));

            unitOfWork.Commit();

            return rooms;
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByPriceRange(double min_price = 0, double max_price = double.MaxValue)
        {
            throw new NotImplementedException();
        }

        public List<RoomInfoUseCaseDTO> GetRoomsByType(RoomType type)
        {
            throw new NotImplementedException();
        }

        public List<RoomInfoUseCaseDTO> GetSortedRoomsByCapacity()
        {
            throw new NotImplementedException();
        }

        public List<RoomInfoUseCaseDTO> GetSortedRoomsByPrice()
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int roomId)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateRoomUseCaseDTO updateRoomUseCaseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
