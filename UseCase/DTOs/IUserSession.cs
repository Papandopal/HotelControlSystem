using UseCase.DTOs.AuthorisationDTOs;

namespace UseCase.DTOs
{
    public interface IUserSession
    {
        public UserMainInfoDTO currentUser { get; }
        public void SetUser(UserMainInfoDTO user);
        public void Reset();
    }
}
