using Api.Dtos.Customers;
using FluentValidation;

namespace Api.Dtos.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(r => r.Fullname).NotEmpty()
             .WithMessage("Fullname is required");
            RuleFor(r => r.Fullname).MinimumLength(3).MaximumLength(100)
             .WithMessage("Fullname must have between 3 and 100 characters");

            RuleFor(r => r.Email).NotEmpty()
             .WithMessage("Email is required");
            RuleFor(r => r.Email).EmailAddress()
              .WithMessage("Email must be a valid email address");

            RuleFor(r => r.Phone).NotEmpty()
              .WithMessage("Phone is required");
            RuleFor(r => r.Phone).Matches(@"^(\+[1-9])?\d{6,15}$")
              .WithMessage("Phone must be a valid phone number");

            RuleFor(r => r.Address).NotEmpty()
              .WithMessage("Address is required");
            RuleFor(r => r.Address).MinimumLength(5)
             .WithMessage("Address must have at least 5 characters");

            RuleFor(r => r.BirthDate).NotEmpty()
              .WithMessage("BirthDate is required");
            RuleFor(r => r.BirthDate).LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Birth date invalid");
        }
    }
}
