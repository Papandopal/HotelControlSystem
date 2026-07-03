using Adapters.DTO.HotelDTOs;
using Adapters.DTO.UserDTOs;
using Adapters.DTOs.AuthorisationDTOs;
using AutoMapper;
using DoMain.Entities;
using HotelControlSystem.DTO.HotelDTOs;
using HotelControlSystem.DTO.UserDTOs;
using HotelControlSystem.DTOs.AuthorisationDTOs;
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
        }
    }
}
