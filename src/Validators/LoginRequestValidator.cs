using FluentValidation;
using wobble.src.Requests;

namespace wobble.src.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}