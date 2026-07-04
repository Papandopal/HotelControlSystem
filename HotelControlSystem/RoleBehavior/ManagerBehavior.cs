using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.Controllers.Console;
using Adapters.DTOs.HotelDTOs;
using AutoMapper;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.HotelDTOs;

namespace HotelControlSystem.RoleBehavior
{
    internal class ManagerBehavior
    {
        public List<Action> Actions { get; set; } = new List<Action>();

        private UserMainInfoDTO userMainInfo;
        private HotelController hotelController;
        private Paginator<HotelInfoConsoleDTO> hotelPaginator;

        private IMapper mapper;
        public ManagerBehavior(UserMainInfoDTO userMainInfo, HotelController hotelController,
            Paginator<HotelInfoConsoleDTO> hotelPaginator, IMapper mapper)
        {
            this.userMainInfo = userMainInfo;
            this.hotelController = hotelController;
            this.hotelPaginator = hotelPaginator;
            this.mapper = mapper;

            //MethodNames must be called "***Action"
            Actions.AddRange(GetHotelsAction, UpdateHotelAction);
        }

        private void GetHotelsAction()
        {
            List<HotelInfoConsoleDTO> hotels = mapper.Map<List<HotelInfoConsoleDTO>>
                (hotelController.GetHotelsByManagerId(userMainInfo.Id));

            hotelPaginator.SetItems(hotels);
            hotelPaginator.StartPagination();
        }

        private UpdateHotelConsoleDTO CreateUpdateHotelConsoleDTO(UpdateHotelConsoleDTO updatedHotel)
        {
            string? country, city, address, name;

            Input.TryGetItem("Country: ", out country);
            Input.TryGetItem("City: ", out city);
            Input.TryGetItem("Address: ", out address);
            Input.TryGetItem("Name: ", out name);

            var new_hotel_info = new UpdateHotelConsoleDTO
            {
                Id = updatedHotel.Id,
                Country = country ?? updatedHotel.Country,
                City = city ?? updatedHotel.City,
                Address = address ?? updatedHotel.Address,
                Name = name ?? updatedHotel.Name
            };

            return new_hotel_info;
        }

        private void UpdateHotelAction()
        {
            int hotel_id;
            Input.GetItem("Hotel id: ", out hotel_id);

            while (!hotelController.IsExists(hotel_id))
            {
                Output.WriteLine("Hotel not found");
                Input.GetItem("Hotel id: ", out hotel_id);
            }

            UpdateHotelConsoleDTO updatedHotel = mapper.Map<UpdateHotelConsoleDTO>(hotelController.GetById(hotel_id));

            UpdateHotelConsoleDTO updateHotelConsoleDTO = CreateUpdateHotelConsoleDTO(updatedHotel);

            hotelController.Update(mapper.Map<UpdateHotelDTO>(updateHotelConsoleDTO));
        }
    }
}
