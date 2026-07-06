using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapters.DTOs.LoyaltyProgramDTOs;
using AutoMapper;
using UseCase.DTOs.LoyaltyProgrammDTOs;
using UseCase.Services.LoyaltyProgramServices;

namespace Adapters.Controllers.Console
{
    public class LoyaltyProgramController(ILoyaltyProgramService loyaltyProgramService, IMapper mapper)
    {
        public void Create(CreateLoyaltyProgramDTO createLoyaltyProgramDTO)
        {
            loyaltyProgramService.Create(mapper.Map<CreateLoyaltyProgramUseCaseDTO>(createLoyaltyProgramDTO));
        }

        public void Update(UpdateLoyaltyProgramDTO updateLoyaltyProgramDTO) 
        {
            loyaltyProgramService.Update(mapper.Map<UpdateLoyaltyProgramUseCaseDTO>(updateLoyaltyProgramDTO));
        }

        public bool IsExistsByUserId(int userId)
        {
            return loyaltyProgramService.IsExistsByUserId(userId);
        }

        public decimal GetSaleProcentByUserId(int userId)
        {
            return loyaltyProgramService.GetSaleProcentByUserId(userId);
        }
    }
}
