using DoMain.Entities;

namespace UseCase.Database.Repositories
{
    public interface ILoyaltyProgramRepository : IRepository<LoyaltyProgram>
    {
        public bool IsExistsByUserId(int userId);
        public LoyaltyProgram GetByUserId(int userId);
    }
}
