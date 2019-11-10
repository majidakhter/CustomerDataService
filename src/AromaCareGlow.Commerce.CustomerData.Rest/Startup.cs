using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Map;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Seed;
using AromaCareGlow.Commerce.CustomerData.Model.Map;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AromaCareGlow.Commerce.CustomerData.Rest.Database;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using AromaCareGlow.Commerce.CustomerData.Rest.V1;

namespace AromaCareGlow.Commerce.CustomerData.Rest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDependencyServices();

            services.AddSingleton<IEntityTypeMap, CustomerMap>();
            services.AddSingleton<IEntityTypeMap, CustomerPasswordMap>();
            // Register the Seed:
            services.AddSingleton<IDbContextSeed, DbContextSeed>();

            // Add the DbContextOptions:
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options;

            services.AddSingleton(dbContextOptions);

            // Finally register the DbContextOptions:
            services.AddSingleton<ApplicationDbContextOptions>();

            // This Factory is used to create the DbContext from the custom DbContextOptions:
            services.AddSingleton<IApplicationDbContextFactory, ApplicationDbContextFactory>();

            // Finally Add the Applications DbContext:
            services.AddDbContext<ApplicationDbContext>();
            services.AddVersionedApiExplorer(o => { o.GroupNameFormat = "'v'VVV"; o.SubstituteApiVersionInUrl = true; });
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
           
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<CustomerController>>();
            services.AddSingleton(typeof(ILogger), logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(
               options =>
               {
                   foreach (var description in provider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                   }
               });

        }
    }
}
