using CarBookingManager.API.Dtos.Requests;
using FluentValidation;

namespace CarBookingManager.API.Validators
{
    public class CarRequestValidator:AbstractValidator<CarRequest>
    {
        public CarRequestValidator()
        {
            RuleFor(c => c.Year).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow.Year);
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Fuel).NotEmpty();
            RuleFor(c => c.Power).NotEmpty();
      
        }
    }
}
