using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zip.Database.Repositories;

namespace Zip.Business.Users.Queries.GetUsers
{
    public class GetUsersHandler : ZipHandler<GetUsersRequest, GetUsersResponse>
    {
        private IUserRepository Users { get; }

        public GetUsersHandler(IMediator mediator, IUserRepository users)
            : base(mediator)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        protected override async Task<GetUsersResponse> Execute(GetUsersRequest request, CancellationToken token)
        {
            var result = new GetUsersResponse();

            result.Users.AddRange(await Users.GetUsers());

            return result;
        }
    }
}