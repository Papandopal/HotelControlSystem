using UseCase.DTOs;
using UseCase.DTOs.AuthorisationDTOs;

namespace HotelControlSystem.DTOs
{
    public class UserSession : IUserSession
    {
        public UserMainInfoDTO currentUser { get; private set; } = new();

        public void Reset()
        {
            currentUser.Reset();
        }

        public void SetUser(UserMainInfoDTO user)
        {
            currentUser = user;
        }

        public override string ToString()
        {
            return currentUser.ToString();
        }
    }
}
