using DoMain.Entities;

namespace UseCase.DTOs.LoyaltyProgrammDTOs
{
    public class CreateLoyaltyProgramUseCaseDTO
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
