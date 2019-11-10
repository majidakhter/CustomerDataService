using AromaCareGlow.Commerce.CustomerData.Rest;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Xunit;

namespace AromaCareGlow.Commerce.CustomerData.IntegrationTest
{
    public class TestFixture : IDisposable
    {

        public TestFixture()
            : this(Path.Combine(""))
        {
        }

        public HttpClient Client { get; }
        private TestServer Server { get; set; }
        public void Dispose()
        {
            Client.Dispose();
        }
        public static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            var projectName = startupAssembly.GetName().Name;

            var applicationBasePath = AppContext.BaseDirectory;

            var directoryInfo = new DirectoryInfo(applicationBasePath);

            do
            {
                directoryInfo = directoryInfo.Parent;

                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));

                if (projectDirectoryInfo.Exists)
                    if (new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj")).Exists)
                        return Path.Combine(projectDirectoryInfo.FullName, projectName);
            }
            while (directoryInfo.Parent != null);

            return string.Empty;
        }

        private static IConfiguration Configuration =>
        new ConfigurationBuilder()
            .SetBasePath(GetProjectPath("", typeof(TestFixture).GetTypeInfo().Assembly))
            .AddJsonFile("appSettings.json", true, false)
            .AddEnvironmentVariables()
            .Build();

        protected TestFixture(string relativeTargetProjectParentDir)
        {
         #if DEBUG

            Server = new TestServer(new WebHostBuilder()
                .UseConfiguration(Configuration)
                          .UseStartup<Startup>());
            Client = Server.CreateClient();
         #elif (!DEBUG)
             var startupAssembly = typeof(TestFixture).GetTypeInfo().Assembly;
                        var path = GetProjectPath("", startupAssembly);
                        var sqsUrl = Configuration.GetSection($"API:SQSAPI").Value;
                        Client = new HttpClient();
                        Client.BaseAddress = new Uri(sqsUrl);
                        Client.DefaultRequestHeaders.Accept.Clear();
         #endif

        }
    }
}
