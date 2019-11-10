using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Infrastructure.Map
{
    public abstract class BaseEntityMap<TEntityType> : IEntityTypeMap
      where TEntityType : class
    {
        public void Map(ModelBuilder builder)
        {
            InternalMap(builder.Entity<TEntityType>());
        }

        protected abstract void InternalMap(EntityTypeBuilder<TEntityType> builder);
    }
}
