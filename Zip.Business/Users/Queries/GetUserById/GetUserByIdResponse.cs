using Zip.Domain;

namespace Zip.Business.Users.Queries.GetUserById
{
    public class GetUserByIdResponse : ZipResponse
    {
        public User User { get; set; }
    }
}