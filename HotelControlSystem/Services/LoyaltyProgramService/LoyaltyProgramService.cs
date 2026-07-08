using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoMain.Entities;
using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs.BookingDTOs;
using UseCase.DTOs.LoyaltyProgrammDTOs;
using UseCase.Services.BookingService;
using UseCase.Services.LoyaltyProgramServices;

namespace HotelControlSystem.Services.LoyaltyProgramService
{
    public class LoyaltyProgramService : ILoyaltyProgramService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private IValidator<CreateLoyaltyProgramUseCaseDTO> createValidator;
        public LoyaltyProgramService(IUnitOfWork unitOfWork, IMapper mapper, IBookingService bookingService, 
            IValidator<CreateLoyaltyProgramUseCaseDTO> createValidator)
        {
            bookingService.BookingComplited += BookingComplitedHandler;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.createValidator = createValidator;
        }

        private void BookingComplitedHandler(BookingComplitedUseCaseDTO bookingCreatedUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var loyaltyProgramExists = unitOfWork.LoyaltyPrograms.IsExistsByUserId(bookingCreatedUseCaseDTO.UserId);

            if (!loyaltyProgramExists)
            {
                unitOfWork.Commit();
                return;
            }

            var loyaltyProgram = unitOfWork.LoyaltyPrograms.GetByUserId(bookingCreatedUseCaseDTO.UserId);

            loyaltyProgram.UpdateAfterPurchase(bookingCreatedUseCaseDTO.TotalPrice, 0.1M);

            unitOfWork.LoyaltyPrograms.Update(loyaltyProgram);

            unitOfWork.Commit();
        }

        public void Create(CreateLoyaltyProgramUseCaseDTO createLoyaltyProgramUseCaseDTO)
        {
            createValidator.ValidateAndThrow(createLoyaltyProgramUseCaseDTO);

            unitOfWork.StartTransaction();

            var related_user = unitOfWork.Users.GetById(createLoyaltyProgramUseCaseDTO.UserId);

            createLoyaltyProgramUseCaseDTO.User = related_user;

            var new_loyalty_program = mapper.Map<LoyaltyProgram>(createLoyaltyProgramUseCaseDTO);

            unitOfWork.LoyaltyPrograms.Add(new_loyalty_program);

            unitOfWork.Commit();
        }

        public List<LoyaltyProgramInfoUseCaseDTO> GetAll()
        {
            unitOfWork.StartTransaction();

            var lotaltyPrograms = mapper.Map<List<LoyaltyProgramInfoUseCaseDTO>>(unitOfWork.LoyaltyPrograms.GetAll());

            unitOfWork.Commit();

            return lotaltyPrograms;
        }

        public decimal GetSaleProcentByUserId(int userId)
        {
            unitOfWork.StartTransaction();

            LoyaltyProgramTier tier = unitOfWork.LoyaltyPrograms.GetByUserId(userId).Tier;

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
    }
}
