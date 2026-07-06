using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoMain.Entities;

namespace UseCase.DTOs.LoyaltyProgrammDTOs
{
    public class CreateLoyaltyProgramUseCaseDTO
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
