using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using UseCase.Database;
using UseCase.DTOs.LoyaltyProgrammDTOs;
using UseCase.Services.LoyaltyProgramServices;

namespace HotelControlSystem.Services.LoyaltyProgramService
{
    public class LoyaltyProgramSevice(IUnitOfWork unitOfWork, IMapper mapper) : ILoyaltyProgramService
    {
        public void Create(CreateLoyaltyProgramUseCaseDTO createLoyaltyProgramUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var related_user = unitOfWork.Users.GetById(createLoyaltyProgramUseCaseDTO.UserId);

            createLoyaltyProgramUseCaseDTO.User = related_user;

            var new_loyalty_program = mapper.Map<LoyaltyProgram>(createLoyaltyProgramUseCaseDTO);

            unitOfWork.Commit();
        }

        public decimal GetSaleProcentByUserId(int userId)
        {
            unitOfWork.StartTransaction();

            LoyaltyProgramTier tier = unitOfWork.LoyaltyPrograms.GetById(userId).Tier;

            decimal procent = (int)tier * 5;

            unitOfWork.Commit();

            return procent;
        }

        public bool IsExistsByUserId(int userId)
        {
            unitOfWork.StartTransaction();

            var isExists = unitOfWork.LoyaltyPrograms.IsExistsByUserId(userId);

            unitOfWork.Commit();

            return isExists;
        }

        public void Update(UpdateLoyaltyProgramUseCaseDTO updateLoyaltyProgramUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var loyaltyProgram = unitOfWork.LoyaltyPrograms.GetById(updateLoyaltyProgramUseCaseDTO.Id);

            var updatedLoyaltyProgram = mapper.Map(updateLoyaltyProgramUseCaseDTO, loyaltyProgram);

            unitOfWork.LoyaltyPrograms.Update(updatedLoyaltyProgram);

            unitOfWork.Commit();
        }
    }
}
