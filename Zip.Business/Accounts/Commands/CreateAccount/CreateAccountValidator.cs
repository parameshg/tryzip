using FluentValidation;

namespace Zip.Business.Accounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
    {
        public CreateAccountValidator()
        {
            RuleFor(i => i.UserId).NotEmpty().WithMessage("UserId is required to create an account");
        }
    }
}