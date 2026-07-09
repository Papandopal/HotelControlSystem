using AutoMapper;
using DoMain.Entities;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs;
using UseCase.DTOs.AuthorisationDTOs;
using UseCase.Exceptions;

namespace UseCase.Services.AuthorisationServices
{
    public class AuthorisationService(IUserSession userSession, IUnitOfWork unitOfWork, IMapper mapper, IValidator<VerifyUserUseCaseDTO> verifyValidator,
        IValidator<RegistrateUserUseCaseDTO> registrationValidator) : IAuthorisationService
    {
        public void Registration(RegistrateUserUseCaseDTO info)
        {
            registrationValidator.ValidateAndThrow(info);

            unitOfWork.StartTransaction();

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(info.Password);

            var user = mapper.Map<User>(info);
            user.PasswordHash = passwordHash;

            unitOfWork.Users.Add(user);

            unitOfWork.Commit();

            userSession.SetUser(mapper.Map<UserMainInfoDTO>(user));
        }

        public void Verify(VerifyUserUseCaseDTO info)
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
                     userSession.SetUser(mapper.Map<UserMainInfoDTO>(user));
                    return;
                }
            }

            throw new AuthorisationFailedException("Verify failed");
        }
    }
}
