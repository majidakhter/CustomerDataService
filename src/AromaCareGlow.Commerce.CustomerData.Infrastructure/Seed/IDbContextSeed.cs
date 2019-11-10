using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Seed
{
    public interface IDbContextSeed
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
