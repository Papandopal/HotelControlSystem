using AutoMapper;
using DoMain.Enums;
using UseCase.Database;
using UseCase.DTOs;
using UseCase.DTOs.UserDTOs;
using UseCase.Exceptions;

namespace UseCase.Services.UserServices
{
    public class UserService(IUserSession userSession, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
    {
        public void Delete(int id)
        {
            unitOfWork.StartTransaction();

            unitOfWork.Users.Delete(id);

            if(userSession.currentUser.Id == id)
            {
                userSession.Reset();
            }

            unitOfWork.Commit();
        }

        public List<UserInfoUseCaseDTO> GetAllUsers()
        {
            return mapper.Map<List<UserInfoUseCaseDTO>>(unitOfWork.Users.GetAll());
        }

        public void Promote(int id, UserRole new_role)
        {
            unitOfWork.StartTransaction();

            if (userSession.currentUser.Id == id)
            {
                unitOfWork.Rollback();
                throw new AccessDeniedException("user cannot promote yourself");
            }

            var user = unitOfWork.Users.GetById(id);
            user.Role = new_role;
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }

        public bool IsExists(int id)
        {
            unitOfWork.StartTransaction();
            var user = unitOfWork.Users.GetById(id);
            unitOfWork.Commit();
            return user is not null && !user.isDeleted;
        }
    }
}
