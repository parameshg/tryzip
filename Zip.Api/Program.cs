using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Zip.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder();

            host.UseKestrel();

            host.UseContentRoot(Directory.GetCurrentDirectory());

            host.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                configuration.AddEnvironmentVariables();
            });

            host.UseStartup<Startup>();

            host.Build().Run();
        }
    }
}