using CarBookingManager.API.Dtos.Requests;
using FluentValidation;

namespace CarBookingManager.API.Validators
{
    public class ReservationRequestValidator:AbstractValidator<ReservationRequest>
    {
        public ReservationRequestValidator()
        {
            RuleFor(r => r.DateFrom).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow);
            RuleFor(r => r.DateTo).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow).GreaterThanOrEqualTo(r=>r.DateFrom);
            RuleFor(r => r.CustomerPersonalNo).NotEmpty().Matches(@"^\d{11}$");
            RuleFor(r => r.RegistrationNo).NotEmpty();
        }
    }
}
