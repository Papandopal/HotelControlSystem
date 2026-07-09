using UseCase.DTOs.LoyaltyProgrammDTOs;

namespace UseCase.Services.LoyaltyProgramServices
{
    public interface ILoyaltyProgramService
    {
        public void Create(CreateLoyaltyProgramUseCaseDTO createLoyaltyProgramUseCaseDTO);
        public List<LoyaltyProgramInfoUseCaseDTO> GetAll();
        public bool IsExistsByUserId(int userId);
        public decimal GetSaleProcentByUserId(int userId);
    }
}
