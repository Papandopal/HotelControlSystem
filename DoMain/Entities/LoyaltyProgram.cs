using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int UserId { get; set; }
        public User User { get; set; }
        public int TotalPoints { get; set; }
        public LoyaltyProgramTier Tier { get; set; } = LoyaltyProgramTier.Bronze;
        public decimal TotalSpent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime JoinedAt { get; } = DateTime.Now;
        
    }
}
