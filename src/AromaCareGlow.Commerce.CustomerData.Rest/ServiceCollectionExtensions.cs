using AromaCareGlow.Commerce.CustomerData.Domain.Repository;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AromaCareGlow.Commerce.CustomerData.Rest
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(
               options =>
               {
                   var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                   foreach (var description in provider.ApiVersionDescriptions)
                   {
                       options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                   }
               });

            services.AddSingleton<ICustomerRepository, CustomerRepository>();
           
        }
        private static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info
            {
                Title = $"Customer Data Service {description.ApiVersion}",
                Version = description?.ApiVersion?.ToString(),
                Description = "Customer Data Service Version with Swagger and API versioning.",
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
