using AutoMapper;
using BCrypt.Net;
using DoMain.Entities;
using FluentValidation;
using HotelControlSystem.Exceptions;
using UseCase.Database;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.Services.AuthorisationServices;

namespace HotelControlSystem.Services.AuthorisationServices
{
    public class AuthorisationService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<VerifyUserUseCaseDTO> verifyValidator,
        IValidator<RegistrateUserUseCaseDTO> registrationValidator) : IAuthorisationService
    {
        public AuthorisedUserUseCaseDTO Registration(RegistrateUserUseCaseDTO info)
        {
            registrationValidator.ValidateAndThrow(info);

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

            verifyValidator.ValidateAndThrow(info);

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
