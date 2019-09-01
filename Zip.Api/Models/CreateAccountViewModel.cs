using System;
using System.ComponentModel.DataAnnotations;

namespace Zip.Api.Models
{
    public class CreateAccountViewModel
    {
        [Required]
        public Guid UserId { get; set; }
    }
}