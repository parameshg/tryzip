using FluentValidation;

namespace Zip.Business.Accounts.Queries.GetAccounts
{
    public class GetAccountsValidator : AbstractValidator<GetAccountsRequest>
    {
        public GetAccountsValidator()
        {
        }
    }
}