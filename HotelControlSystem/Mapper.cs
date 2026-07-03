using Adapters.DTO.HotelDTOs;
using Adapters.DTO.UserDTOs;
using Adapters.DTOs.AuthorisationDTOs;
using Adapters.DTOs.HotelDTOs;
using AutoMapper;
using DoMain.Entities;
using HotelControlSystem.DTO.HotelDTOs;
using HotelControlSystem.DTO.UserDTOs;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.DTOs.HotelDTOs;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.DTOs.HotelDTOs;
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

            CreateMap<UpdateHotelConsoleDTO, UpdateHotelDTO>().ForAllMembers(
                opt=>opt.Condition((src, dest, srcProperty)=>srcProperty is not null)
            );
            CreateMap<UpdateHotelDTO, UpdateHotelUseCaseDTO>().ForAllMembers(
                opt => opt.Condition((src, dest, srcProperty) => srcProperty is not null)
            );
            CreateMap<UpdateHotelUseCaseDTO, Hotel>().ForAllMembers(
                opt => opt.Condition((src, dest, srcProperty) => srcProperty is not null)
            );
        }
    }
}
