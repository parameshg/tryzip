using System.ComponentModel.DataAnnotations;

namespace Zip.Api.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public float Salary { get; set; }

        [Required]
        public float Expense { get; set; }
    }
}