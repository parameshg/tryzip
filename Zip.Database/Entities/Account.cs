using System;

namespace Zip.Database.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public float Balance { get; set; }
    }
}