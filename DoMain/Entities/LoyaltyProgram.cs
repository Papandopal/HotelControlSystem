using DoMain.Enums;

namespace DoMain.Entities
{
    public class LoyaltyProgram
    {
        private LoyaltyProgram() { }
        public LoyaltyProgram(User user) 
        {
            User = user;
        }
        public int Id { get; init; }
        public int UserId { get; init; }
        public User User { get; init; }
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
        public DateTime JoinedAt { get; } = DateTime.Now;
        public void UpdateAfterPurchase(decimal price, decimal coefForPoints)
        {
            TotalSpent += price;
            TotalPoints += (int)(price * coefForPoints);
        }

    }
}
