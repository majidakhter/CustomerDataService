using System;
using System.Collections.Generic;
using System.Text;
using AromaCareGlow.Commerce.CustomerData.Infrastructure.Context;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Factory
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
