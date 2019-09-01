using System.Collections.Generic;
using Zip.Domain;

namespace Zip.Business.Users.Queries.GetUsers
{
    public class GetUsersResponse : ZipResponse
    {
        public List<User> Users { get; set; }

        public GetUsersResponse()
        {
            Users = new List<User>();
        }
    }
}