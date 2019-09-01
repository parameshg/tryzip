using System;

namespace Zip.Business.Users.Queries.GetUserById
{
    public class GetUserByIdRequest : ZipRequest<GetUserByIdResponse>
    {
        public Guid UserId { get; set; }
    }
}