using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTO;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.Services.UserServices;
using UseCase.Services.UserServices.DTO;

namespace HotelControlSystem.Services.UserServices
{
    internal class UserService(UserMainInfoDTO userMainInfo, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        public void DeleteUserById(int id)
        {
            unitOfWork.StartTransaction();

            userRepository.Delete(id);
            if (userMainInfo.Id == id)
            {
                userMainInfo.Reset();
            }

            unitOfWork.Commit();
        }

        public List<UserInfoUseCaseDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoUseCaseDTO>>(userRepository.GetAll());
        }

        public void PromoteUserById(int id, UserRole new_role)
        {
            unitOfWork.StartTransaction();

            if (userMainInfo.Id == id)
            {
                unitOfWork.Rollback();
                throw new AccessDeniedException("user cannot promote yourself");
            }

            var user = userRepository.GetById(id);
            user.Role = new_role;
            userRepository.Update(user);

            unitOfWork.Commit();
        }
    }
}
