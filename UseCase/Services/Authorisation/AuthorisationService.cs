using AutoMapper;
using DoMain.Entities;
using UseCase.Database;
using UseCase.DTO;
using UseCase.Exceptions;

namespace UseCase.Services.Authorisation
{
    public class AuthorisationService(IUnitOfWork unitOfWork, IMapper mapper) : IAuthorisationService
    {
        public AuthorisedUserDTO Registration(RegistrateUserUseCaseDTO info)
        {
            unitOfWork.StartTransaction();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(info.Password);
            var user = mapper.Map<User>(info);
            user.PasswordHash = passwordHash;
            unitOfWork.Users.Add(user);
            unitOfWork.Commit();
            return mapper.Map<AuthorisedUserDTO>(user);
        }

        public AuthorisedUserDTO Verify(VerifyUserDTO info)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(info.Password);
            var user = unitOfWork.Users.GetByUserName(info.UserName);
            if (user.PasswordHash != passwordHash) throw new AuthorisationFailedException("Verify failed");
            return mapper.Map<AuthorisedUserDTO>(user);
        }
    }
}
