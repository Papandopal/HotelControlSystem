using DoMain.Enums;

namespace HotelControlSystem.DTOs.LoyaltyProgramDTO
{
    public class LoyaltyProgramInfoConsoleDTO
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public int TotalPoints { get; set; }
        public LoyaltyProgramTier Tier => TotalPoints switch
        {
            < 500 => LoyaltyProgramTier.Bronze,
            < 5000 => LoyaltyProgramTier.Silver,
            < 10000 => LoyaltyProgramTier.Gold,
            _ => LoyaltyProgramTier.Platinum
        };
        public decimal TotalSpent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime JoinedAt { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"UserId: {UserId}\n" +
                   $"TotalPoints: {TotalPoints}\n" +
                   $"TotalSpent: {TotalSpent}\n" +
                   $"Tier: {Tier}";
        }
    }
}
