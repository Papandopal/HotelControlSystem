using AutoMapper;
using DoMain.Entities;
using UseCase.DTO;

namespace UseCase.Services.Authorisation
{
    public class AuthorisationService(IUnitOfWork unitOfWork, IMapper mapper) : IAuthorisationService
    {
        public AuthorisedUser Registration(RegistrationUserDTO info)
        {
            unitOfWork.StartTransaction();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(info.Password);
            var user = new User { UserName = info.Name, Email = info.Email, PasswordHash = passwordHash };
            unitOfWork.Users.Add(user);
            unitOfWork.Commit();
            return mapper.Map<AuthorisedUser>(user);
        }

        public AuthorisedUser Verify(VerifyUserDTO info)
        {
            throw new NotImplementedException();
        }
    }
}
