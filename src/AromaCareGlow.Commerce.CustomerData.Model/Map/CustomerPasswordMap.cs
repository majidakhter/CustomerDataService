using AromaCareGlow.Commerce.CustomerData.Infrastructure.Map;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Model.Map
{
    public class CustomerPasswordMap : BaseEntityMap<CustomerPassword>
    {
        protected override void InternalMap(EntityTypeBuilder<CustomerPassword> builder)
        {
            builder
                  .ToTable("CustomerPassword", "CustomerPasswordInfo");
            builder
                .HasKey(x => x.Id)
                .HasName("PK_CustomerPassword");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("CustomerId");
            builder
              .Property(x => x.Password)
              .HasColumnName("Password");
            builder
            .Property(x => x.PasswordFormatId)
            .HasColumnName("PasswordFormatId");
            builder
           .Property(x => x.PasswordSalt)
           .HasColumnName("PasswordSalt");
            builder
          .Property(x => x.CreatedOnUtc)
          .HasColumnName("CreatedOnUtc");
        }
    }
}
