using Microsoft.EntityFrameworkCore;
using Zip.Database.Entities;

namespace Zip.Database
{
    public class ZipDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public ZipDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlite(@"Data Source=zip.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder o)
        {
            o.Entity<User>().HasKey(i => i.Id);
            o.Entity<User>().Property(i => i.Name).IsRequired().HasMaxLength(256);
            o.Entity<User>().Property(i => i.Email).IsRequired().HasMaxLength(256);
            o.Entity<User>().Property(i => i.Salary).IsRequired();
            o.Entity<User>().Property(i => i.Expense).IsRequired();

            o.Entity<Account>().HasKey(i => i.Id);
            o.Entity<Account>().Property(i => i.Name).IsRequired().HasMaxLength(256);
            o.Entity<Account>().HasOne(i => i.User);
        }
    }
}