using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Zip.Database
{
    public class DesignTimeSqlServerDbContextFactory : IDesignTimeDbContextFactory<ZipDbContext>
    {
        public ZipDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZipDbContext>();

            builder.UseSqlite(@"Data Source=zip.db;Version=3;");

            return new ZipDbContext(builder.Options);
        }
    }

    public class DesignTimeSqliteDbContextFactory : IDesignTimeDbContextFactory<ZipDbContext>
    {
        public ZipDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZipDbContext>();

            builder.UseSqlite(@"Data Source=zip.db;Version=3;");

            return new ZipDbContext(builder.Options);
        }
    }
}