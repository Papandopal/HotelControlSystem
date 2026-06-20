using AutoMapper;
using BCrypt.Net;
using DoMain.Entities;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.Services.AuthorisationServices;
using UseCase.Services.AuthorisationServices.DTO;

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
            User user = unitOfWork.Users.GetByUserName(info.UserName);
            string password = info.Password;
            string hash = user.PasswordHash;
            if (!BCrypt.Net.BCrypt.Verify(password, hash)) throw new AuthorisationFailedException("Verify failed");
            return mapper.Map<AuthorisedUserUseCaseDTO>(user);
        }
    }
}
