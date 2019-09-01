using FluentValidation;

namespace Zip.Business.Users.Queries.GetUsers
{
    public class GetUsersValidator : AbstractValidator<GetUsersResponse>
    {
        public GetUsersValidator()
        {
        }
    }
}