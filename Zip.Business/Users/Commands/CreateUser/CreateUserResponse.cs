using System;

namespace Zip.Business.Users.Commands.CreateUser
{
    public class CreateUserResponse : ZipResponse
    {
        public Guid UserId { get; set; }
    }
}