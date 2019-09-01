using System;

namespace Zip.Business.Accounts.Commands.CreateAccount
{
    public class CreateAccountRequest : ZipRequest<CreateAccountResponse>
    {
        public Guid UserId { get; set; }
    }
}