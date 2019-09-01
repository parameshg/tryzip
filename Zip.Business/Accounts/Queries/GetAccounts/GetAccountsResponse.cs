using System.Collections.Generic;
using Zip.Domain;

namespace Zip.Business.Accounts.Queries.GetAccounts
{
    public class GetAccountsResponse : ZipResponse
    {
        public List<Account> Accounts { get; set; }

        public GetAccountsResponse()
        {
            Accounts = new List<Account>();
        }
    }
}