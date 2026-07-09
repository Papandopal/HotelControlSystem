using DoMain.Enums;
using FluentValidation;
using UseCase.Database;
using UseCase.DTOs;
using UseCase.DTOs.HotelDTOs;

namespace UseCase.Validators.HotelValidators
{
    public class CreateHotelValidator : AbstractValidator<CreateHotelUseCaseDTO>
    {
        public CreateHotelValidator(IUserSession userSession, IUnitOfWork unitOfWork) 
        {
            RuleFor(x=>x.ManagerId).Must(managerId =>
            {
                unitOfWork.StartTransaction();

                var manager = unitOfWork.Users.GetById(managerId);

                unitOfWork.Commit();

                return manager.Role == UserRole.HotelManager;
            }).WithMessage("incoming \"manager id\" is not id of hotel manager");

            RuleFor(x => x.Name).Must(managerName => 
            {
                return userSession.currentUser.Role == UserRole.Admin;
            }).WithMessage("Access denied");

            RuleFor(x => x.Name).Must((dto, name)  =>
            {
                unitOfWork.StartTransaction();

                var hotels = unitOfWork.Hotels.GetHotelsByCity(dto.City);
                foreach (var item in hotels)
                {
                    if (item.Name == name && item.Country == dto.Country)
                    {
                        unitOfWork.Rollback();
                        return false;
                    }
                }

                unitOfWork.Commit();

                return true;
            }).WithMessage("name must be unique in city");
        }
    }
}
