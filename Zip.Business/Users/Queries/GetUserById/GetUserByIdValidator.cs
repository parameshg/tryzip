using FluentValidation;

namespace Zip.Business.Users.Queries.GetUserById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdValidator()
        {
            RuleFor(i => i.UserId).NotEmpty().WithMessage("User id is required to fetch user details");
        }
    }
}