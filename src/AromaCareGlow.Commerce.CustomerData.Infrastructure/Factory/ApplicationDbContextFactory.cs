using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly ApplicationDbContextOptions options;

        public ApplicationDbContextFactory(ApplicationDbContextOptions options)
        {
            this.options = options;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(options);
        }
    }
}
