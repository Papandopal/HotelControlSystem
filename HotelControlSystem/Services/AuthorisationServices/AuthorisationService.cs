using AutoMapper;
using BCrypt.Net;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.Services.AuthorisationServices;

namespace HotelControlSystem.Services.AuthorisationServices
{
    public class AuthorisationService(IUnitOfWork unitOfWork, IMapper mapper) : IAuthorisationService
    {
        public AuthorisedUserUseCaseDTO Registration(RegistrateUserUseCaseDTO info)
        {
            unitOfWork.StartTransaction();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(info.Password);
            var user = mapper.Map<User>(info);
            user.PasswordHash = passwordHash;
            unitOfWork.Users.Add(user);
            unitOfWork.Commit();
            return mapper.Map<AuthorisedUserUseCaseDTO>(user);
        }

        public AuthorisedUserUseCaseDTO Verify(VerifyUserUseCaseDTO info)
        {
            IEnumerable<User> users = unitOfWork.Users.GetUsersByUserName(info.UserName);
            string password = info.Password;
            foreach (User user in users)
            {
                if (user.isDeleted) continue;

                string hash = user.PasswordHash;

                if (BCrypt.Net.BCrypt.Verify(password, hash))
                {
                    return mapper.Map<AuthorisedUserUseCaseDTO>(user);
                }
            }

            throw new AuthorisationFailedException("Verify failed");
        }
    }
}
