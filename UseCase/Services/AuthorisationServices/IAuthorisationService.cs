using UseCase.DTOs.AuthorisationDTOs;

namespace UseCase.Services.AuthorisationServices
{
    public interface IAuthorisationService
    {
        public void Verify(VerifyUserUseCaseDTO info);
        public void Registration(RegistrateUserUseCaseDTO info);
    }
}
