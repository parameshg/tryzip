using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zip.Database.Repositories;

namespace Zip.Business.Accounts.Queries.GetAccounts
{
    public class GetAccountsHandler : ZipHandler<GetAccountsRequest, GetAccountsResponse>
    {
        public IAccountRepository Accounts { get; }

        public GetAccountsHandler(IMediator mediator, IAccountRepository accounts)
            : base(mediator)
        {
            Accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        }

        protected override async Task<GetAccountsResponse> Execute(GetAccountsRequest request, CancellationToken token)
        {
            var result = new GetAccountsResponse();

            result.Accounts.AddRange(await Accounts.GetAccounts());

            return result;
        }
    }
}