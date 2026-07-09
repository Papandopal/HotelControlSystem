using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public IEnumerable<User> GetUsersByUserName(string userName);
    }
}
