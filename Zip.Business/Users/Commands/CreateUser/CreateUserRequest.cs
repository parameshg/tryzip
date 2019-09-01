namespace Zip.Business.Users.Commands.CreateUser
{
    public class CreateUserRequest : ZipRequest<CreateUserResponse>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public float Salary { get; set; }

        public float Expense { get; set; }
    }
}