using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.DTOs.RoomDTOs;

namespace HotelControlSystem.Validators.RoomValidators
{
    public class UpdateRoomUseCaseValidator : AbstractValidator<UpdateRoomUseCaseDTO>
    {
        public UpdateRoomUseCaseValidator() 
        {

        }
    }
}
