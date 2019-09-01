using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zip.Database.Repositories;

namespace Zip.Business.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : ZipHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        public IUserRepository Users { get; }

        public GetUserByIdHandler(IMediator mediator, IUserRepository users)
            : base(mediator)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        protected override async Task<GetUserByIdResponse> Execute(GetUserByIdRequest request, CancellationToken token)
        {
            var result = new GetUserByIdResponse();

            result.User = await Users.GetUserById(request.UserId);

            return result;
        }
    }
}