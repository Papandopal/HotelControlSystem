using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTO;
using AutoMapper;
using DoMain.Entities;
using HotelControlSystem.DTO;
using UseCase.DTO;

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
        }
    }
}
