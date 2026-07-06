using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.DTOs.LoyaltyProgrammDTOs;

namespace UseCase.Services.LoyaltyProgramServices
{
    public interface ILoyaltyProgramService
    {
        public void Create(CreateLoyaltyProgramUseCaseDTO createLoyaltyProgramUseCaseDTO);
        public void Update(UpdateLoyaltyProgramUseCaseDTO updateLoyaltyProgramUseCaseDTO);
        public bool IsExistsByUserId(int userId);
        public decimal GetSaleProcentByUserId(int userId);
    }
}
