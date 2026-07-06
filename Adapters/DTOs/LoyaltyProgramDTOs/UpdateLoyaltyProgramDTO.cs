using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.DTOs.LoyaltyProgramDTOs
{
    public class UpdateLoyaltyProgramDTO
    {
        public int Id { get; init; }
        public int TotalPoints { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
