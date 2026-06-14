using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Entities;
using UseCase.DTO;

namespace HotelControlSystem
{
    internal class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<User, AuthorisedUser>();
        }
    }
}
