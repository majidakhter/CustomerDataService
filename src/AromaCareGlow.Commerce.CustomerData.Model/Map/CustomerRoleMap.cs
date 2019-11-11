using AromaCareGlow.Commerce.CustomerData.Infrastructure.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Model.Map
{
    public class CustomerRoleMap: BaseEntityMap<CustomerRole>
    {
        protected override void InternalMap(EntityTypeBuilder<CustomerRole> builder)
        {
            builder
                 .ToTable("CustomerRole");
            builder
                .HasKey(x => x.Id)
                .HasName("PK_CustomerRole");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("Name");
            builder
                .Property(x => x.FreeShipping)
                .HasColumnName("FreeShipping");
            builder
               .Property(x => x.TaxExempt)
               .HasColumnName("TaxExempt");
            builder
              .Property(x => x.Active)
              .HasColumnName("Active");
            builder
              .Property(x => x.IsSystemRole)
              .HasColumnName("IsSystemRole");
            builder
             .Property(x => x.SystemName)
             .HasColumnName("SystemName");
            builder
             .Property(x => x.EnablePasswordLifetime)
             .HasColumnName("EnablePasswordLifetime");
            builder
            .Property(x => x.OverrideTaxDisplayType)
            .HasColumnName("OverrideTaxDisplayType");
            builder
           .Property(x => x.DefaultTaxDisplayTypeId)
           .HasColumnName("DefaultTaxDisplayTypeId");
            builder
          .Property(x => x.PurchasedWithProductId)
          .HasColumnName("PurchasedWithProductId");
        }
    }
}
