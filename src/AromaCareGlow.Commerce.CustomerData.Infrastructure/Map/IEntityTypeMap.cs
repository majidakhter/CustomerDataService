using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Map
{
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }
}
