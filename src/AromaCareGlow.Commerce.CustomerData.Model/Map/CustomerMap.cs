using AromaCareGlow.Commerce.CustomerData.Infrastructure.Map;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Commerce.CustomerData.Model.Map
{
    public class CustomerMap : BaseEntityMap<Customer>
    {
        protected override void InternalMap(EntityTypeBuilder<Customer> builder)
        {
            builder
                 .ToTable("Customer");
            builder
                .HasKey(x => x.Id)
                .HasName("PK_Customer");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Username)
                .HasColumnName("Username");

            builder
                .Property(x => x.Email)
                .HasColumnName("Email");
            builder
                .Property(x => x.IsTaxExempt)
                .HasColumnName("IsTaxExempt");
            builder
                .Property(x => x.EmailToRevalidate)
                .HasColumnName("EmailToRevalidate");
            builder
                .Property(x => x.AdminComment)
                .HasColumnName("AdminComment");
            builder
               .Property(x => x.AffiliateId)
               .HasColumnName("AffiliateId");
            builder
               .Property(x => x.VendorId)
               .HasColumnName("VendorId");
            builder
               .Property(x => x.HasShoppingCartItems)
               .HasColumnName("HasShoppingCartItems");
            builder
               .Property(x => x.RequireReLogin)
               .HasColumnName("RequireReLogin");
            builder
               .Property(x => x.FailedLoginAttempts)
               .HasColumnName("FailedLoginAttempts");
            builder
               .Property(x => x.CannotLoginUntilDateUtc)
               .HasColumnName("CannotLoginUntilDateUtc");
            builder
              .Property(x => x.Active)
              .HasColumnName("Active");
            builder
             .Property(x => x.Deleted)
             .HasColumnName("Deleted");
            builder
            .Property(x => x.IsSystemAccount)
            .HasColumnName("IsSystemAccount");
            builder
            .Property(x => x.SystemName)
            .HasColumnName("SystemName");
            builder
           .Property(x => x.LastIpAddress)
           .HasColumnName("LastIpAddress");
            builder
            .Property(x => x.CreatedOnUtc)
            .HasColumnName("CreatedOnUtc");
             builder
            .Property(x => x.LastLoginDateUtc)
            .HasColumnName("LastLoginDateUtc");
            builder
            .Property(x => x.LastActivityDateUtc)
            .HasColumnName("LastActivityDateUtc");
            builder
            .Property(x => x.RegisteredInStoreId)
            .HasColumnName("RegisteredInStoreId");
            builder
           .Property(x => x.BillingAddressId)
           .HasColumnName("BillingAddress_Id");
            builder
           .Property(x => x.ShippingAddressId)
           .HasColumnName("ShippingAddress_Id");
        }
    }
}
