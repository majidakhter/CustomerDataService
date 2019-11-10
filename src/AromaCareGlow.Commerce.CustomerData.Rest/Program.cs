using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AromaCareGlow.Commerce.CustomerData.Rest
{
    public class Program
    {
        
        private static IConfiguration Configuration =>
            GetConfigurationBuilder();

        private static IConfiguration GetConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appSettings.json", true, false)
            .AddEnvironmentVariables();
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            return builder.Build();
        }
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(Logger)
                .UseConfiguration(Configuration)
                .UseStartup<Startup>();
        }

        private static void Logger(WebHostBuilderContext ctx, ILoggingBuilder logging)
        {
            if (ctx == null || logging == null) return;
            logging.ClearProviders();
            logging.AddEventSourceLogger();
        }
    }
}
