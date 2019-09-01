using System;

namespace Zip.Business.Accounts.Commands.CreateAccount
{
    public class CreateAccountResponse : ZipResponse
    {
        public Guid AccountId { get; set; }
    }
}