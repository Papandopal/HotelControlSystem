using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UseCase.Database;
using UseCase.Services.UserServices;
using UseCase.Services.UserServices.DTO;

namespace HotelControlSystem.Services.UserServices
{
    internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        public List<UserInfoUseCaseDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoUseCaseDTO>>(userRepository.GetAll());
        }
    }
}
