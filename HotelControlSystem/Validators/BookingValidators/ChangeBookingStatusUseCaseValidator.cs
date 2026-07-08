using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.DTOs.BookingDTOs;

namespace HotelControlSystem.Validators.BookingValidators
{
    public class ChangeBookingStatusUseCaseValidator : AbstractValidator<ChangeBookingStatusUseCaseDTO>
    {
        public ChangeBookingStatusUseCaseValidator()
        {

        }
    }
}
