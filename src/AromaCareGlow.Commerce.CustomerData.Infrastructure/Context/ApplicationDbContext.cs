using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Seed;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Map;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Context
{
    public class ApplicationDbContextOptions
    {
        public readonly DbContextOptions<ApplicationDbContext> Options;
        public readonly IDbContextSeed DbContextSeed;
        public readonly IEnumerable<IEntityTypeMap> Mappings;

        public ApplicationDbContextOptions(DbContextOptions<ApplicationDbContext> options, IDbContextSeed dbContextSeed, IEnumerable<IEntityTypeMap> mappings)
        {
            DbContextSeed = dbContextSeed;
            Options = options;
            Mappings = mappings;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContextOptions options;

        public ApplicationDbContext(ApplicationDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var mapping in options.Mappings)
            {
                mapping.Map(builder);
            }

            options.DbContextSeed?.Seed(builder);
        }
    }

    public static class ApplicationDbContextExtensions
    {
        public static DbSet<TEntityType> DbSet<TEntityType>(this ApplicationDbContext context)
            where TEntityType : class
        {
            return context.Set<TEntityType>();
        }
    }
}
