using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zip.Database.Repositories;

namespace Zip.Business.Users.Commands.CreateUser
{
    public class CreateUserHandler : ZipHandler<CreateUserRequest, CreateUserResponse>
    {
        public IUserRepository Users { get; }

        public CreateUserHandler(IMediator mediator, IUserRepository users)
            : base(mediator)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        protected override async Task<CreateUserResponse> Execute(CreateUserRequest request, CancellationToken token)
        {
            var result = new CreateUserResponse();

            var user = await Users.GetUserByEmail(request.Email);

            if (user != null)
            {
                throw new ZipException("user already exists with the same email address");
            }

            var id = Guid.NewGuid();

            var created = await Users.CreateUser(id, request.Name, request.Email, request.Salary, request.Expense);

            result.UserId = created ? id : Guid.Empty;

            return result;
        }
    }
}