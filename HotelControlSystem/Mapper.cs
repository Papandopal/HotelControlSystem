using Adapters.DTO.HotelDTOs;
using Adapters.DTO.UserDTOs;
using Adapters.DTOs.AuthorisationDTOs;
using Adapters.DTOs.BookingDTOs;
using Adapters.DTOs.HotelDTOs;
using Adapters.DTOs.LoyaltyProgramDTOs;
using Adapters.DTOs.RoomDTOs;
using AutoMapper;
using DoMain.Entities;
using HotelControlSystem.DTO.HotelDTOs;
using HotelControlSystem.DTO.UserDTOs;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.BookingDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
using HotelControlSystem.DTOs.LoyaltyProgramDTO;
using HotelControlSystem.DTOs.RoomDTOs;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.DTOs.BookingDTOs;
using UseCase.DTOs.HotelDTOs;
using UseCase.DTOs.LoyaltyProgrammDTOs;
using UseCase.DTOs.RoomDTOs;
using UseCase.DTOs.UserDTOs;

namespace HotelControlSystem
{
    internal class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<RegistrateUserConsoleDTO, RegistrateUserDTO>();
            CreateMap<RegistrateUserDTO, RegistrateUserUseCaseDTO>();
            CreateMap<RegistrateUserUseCaseDTO, User>();

            CreateMap<User, AuthorisedUserUseCaseDTO>();
            CreateMap<AuthorisedUserUseCaseDTO, AuthorisedUserDTO>();
            CreateMap<AuthorisedUserDTO, UserMainInfoDTO>();

            CreateMap<VerifyUserConsoleDTO, VerifyUserDTO>();
            CreateMap<VerifyUserDTO, VerifyUserUseCaseDTO>();

            CreateMap<User, UserInfoUseCaseDTO>();
            CreateMap<UserInfoUseCaseDTO, UserInfoDTO>();
            CreateMap<UserInfoDTO, UserInfoConsoleDTO>();

            CreateMap<HotelManagerAppointmentConsoleDTO, HotelManagerAppointmentDTO>();
            CreateMap<HotelManagerAppointmentDTO, HotelManagerAppointmentUseCaseDTO>();

            CreateMap<CreateHotelConsoleDTO, CreateHotelDTO>();
            CreateMap<CreateHotelDTO, CreateHotelUseCaseDTO>();
            CreateMap<CreateHotelUseCaseDTO, Hotel>();

            CreateMap<Hotel, HotelInfoUseCaseDTO>();
            CreateMap<HotelInfoUseCaseDTO, HotelInfoDTO>();
            CreateMap<HotelInfoDTO, HotelInfoConsoleDTO>();

            CreateMap<UpdateHotelConsoleDTO, UpdateHotelDTO>();
            CreateMap<UpdateHotelDTO, UpdateHotelUseCaseDTO>();
            CreateMap<UpdateHotelUseCaseDTO, Hotel>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
            {
                return srcMember is not null;
            }));

            CreateMap<CreateRoomConsoleDTO, CreateRoomDTO>();
            CreateMap<CreateRoomDTO, CreateRoomUseCaseDTO>();
            CreateMap<CreateRoomUseCaseDTO, Room>();

            CreateMap<Room, RoomInfoUseCaseDTO>();
            CreateMap<RoomInfoUseCaseDTO, RoomInfoDTO>();
            CreateMap<RoomInfoDTO, RoomInfoConsoleDTO>();

            CreateMap<UpdateRoomConsoleDTO, UpdateRoomDTO>();
            CreateMap<UpdateRoomDTO, UpdateRoomUseCaseDTO>();
            CreateMap<UpdateRoomUseCaseDTO, Room>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) =>
            {
                return srcMember is not null;
            }));

            CreateMap<CreateBookingConsoleDTO, CreateBookingDTO>();
            CreateMap<CreateBookingDTO, CreateBookingUseCaseDTO>();
            CreateMap<CreateBookingUseCaseDTO, Booking>().ForMember(desc=>desc.TotalPrice, opt =>
            {
                opt.MapFrom(src => src.Room.PricePerNight * (src.CheckOutDate - src.CheckInDate).Days * (1 - src.SaleProcent*0.01M));
            });

            CreateMap<Booking, BookingInfoForAdminsUseCaseDTO>();
            CreateMap<BookingInfoForAdminsUseCaseDTO, BookingInfoForAdminsDTO>();
            CreateMap<BookingInfoForAdminsDTO, BookingInfoForAdminsConsoleDTO>();

            CreateMap<Booking, BookingInfoForCustomerUseCaseDTO>();
            CreateMap<BookingInfoForCustomerUseCaseDTO, BookingInfoForCustomerDTO>();
            CreateMap<BookingInfoForCustomerDTO, BookingInfoForCustomerConsoleDTO>();

            CreateMap<ChangeBookingStatusConsoleDTO, ChangeBookingStatusDTO>();
            CreateMap<ChangeBookingStatusDTO, ChangeBookingStatusUseCaseDTO>();

            CreateMap<Booking, BookingComplitedUseCaseDTO>();

            CreateMap<CreateLoyaltyProgramConsoleDTO, CreateLoyaltyProgramDTO>();
            CreateMap<CreateLoyaltyProgramDTO, CreateLoyaltyProgramUseCaseDTO>();
            CreateMap<CreateLoyaltyProgramUseCaseDTO, LoyaltyProgram>();

            CreateMap<LoyaltyProgram, LoyaltyProgramInfoUseCaseDTO>();
            CreateMap<LoyaltyProgramInfoUseCaseDTO, LoyaltyProgramInfoDTO>();
            CreateMap<LoyaltyProgramInfoDTO, LoyaltyProgramInfoConsoleDTO>();
        }
    }
}
