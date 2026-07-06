using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Enums;

namespace UseCase.DTOs.LoyaltyProgrammDTOs
{
    public class UpdateLoyaltyProgramUseCaseDTO
    {
        public int TotalPoints { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
