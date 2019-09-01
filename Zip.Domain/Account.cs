using System;

namespace Zip.Domain
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float Balance { get; set; }
    }
}