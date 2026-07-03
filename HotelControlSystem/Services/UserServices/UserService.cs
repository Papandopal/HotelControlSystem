using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.Database.Repositories;
using UseCase.DTOs.UserDTOs;
using UseCase.Services.UserServices;

namespace HotelControlSystem.Services.UserServices
{
    internal class UserService(UserMainInfoDTO userMainInfo, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        public void DeleteUser(int id)
        {
            unitOfWork.StartTransaction();

            unitOfWork.Users.Delete(id);
            if (userMainInfo.Id == id)
            {
                userMainInfo.Reset();
            }

            unitOfWork.Commit();
        }

        public List<UserInfoUseCaseDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoUseCaseDTO>>(unitOfWork.Users.GetAll());
        }

        public void PromoteUser(int id, UserRole new_role)
        {
            unitOfWork.StartTransaction();

            if (userMainInfo.Id == id)
            {
                unitOfWork.Rollback();
                throw new AccessDeniedException("user cannot promote yourself");
            }

            var user = unitOfWork.Users.GetById(id);
            user.Role = new_role;
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public bool UserIsExists(int id)
        {
            unitOfWork.StartTransaction();
            var user = unitOfWork.Users.GetById(id);
            unitOfWork.Commit();
            return user is not null && !user.isDeleted;
        }
    }
}
