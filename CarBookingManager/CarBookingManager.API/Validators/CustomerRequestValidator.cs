using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Models;
using FluentValidation;

namespace CarBookingManager.API.Validators
{
    public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerRequestValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.PersonalNo).NotEmpty().Matches(@"^\d{11}$");
         
        }
    }
}
