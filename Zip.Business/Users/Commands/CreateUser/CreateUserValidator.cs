using FluentValidation;

namespace Zip.Business.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(i => i.Name).NotEmpty().MaximumLength(256).WithMessage("Name no longer than 256 characters is required to create an user");
            RuleFor(i => i.Email).NotEmpty().MaximumLength(256).WithMessage("Email address no longer than 256 characters is required to create an user");
            RuleFor(i => i.Salary).NotEmpty().GreaterThan(0).WithMessage("A positive salary is required to create an user");
            RuleFor(i => i.Expense).NotEmpty().GreaterThan(0).WithMessage("A positive expense is required to create an user");
        }
    }
}