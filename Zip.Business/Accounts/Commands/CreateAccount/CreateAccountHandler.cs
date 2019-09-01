using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zip.Business.Users.Queries.GetUserById;
using Zip.Database.Repositories;

namespace Zip.Business.Accounts.Commands.CreateAccount
{
    public class CreateAccountHandler : ZipHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private IAccountRepository Accounts { get; }

        public CreateAccountHandler(IMediator mediator, IAccountRepository accounts)
            : base(mediator)
        {
            Accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        }

        protected override async Task<CreateAccountResponse> Execute(CreateAccountRequest request, CancellationToken token)
        {
            var result = new CreateAccountResponse();

            var response = await Mediator.Send(new GetUserByIdRequest() { UserId = request.UserId });

            if (response == null || response.User == null)
            {
                throw new ZipException("user not found");
            }

            if (response.User.Salary - response.User.Expense < 1000)
            {
                throw new ZipException("minimum salary requirement not met to created an account");
            }

            var id = Guid.NewGuid();

            var created = await Accounts.CreateAccount(id, request.UserId, "Credit Account", 1000);

            result.AccountId = created ? id : Guid.Empty;

            return result;
        }
    }
}