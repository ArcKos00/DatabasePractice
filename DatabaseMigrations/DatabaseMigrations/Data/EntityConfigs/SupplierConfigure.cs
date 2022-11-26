using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.EntityConfigs
{
    public class SupplierConfigure : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(k => k.SupplierId);

            builder.Property(p => p.SupplierId).HasColumnName("SupplierId").IsRequired(true);
            builder.Property(p => p.CompanyName).HasColumnName("CompanyName").IsRequired(true);
            builder.Property(p => p.ContactFName).HasColumnName("ContactFName").IsRequired(true);
            builder.Property(p => p.ContactLName).HasColumnName("ContactLName").IsRequired(true);
            builder.Property(p => p.ContactTitle).HasColumnName("ContactTitle").IsRequired(true);
            builder.Property(p => p.Address1).HasColumnName("Address1").IsRequired(true);
            builder.Property(p => p.Address2).HasColumnName("Address2").IsRequired(true);
            builder.Property(p => p.City).HasColumnName("City").IsRequired(true);
            builder.Property(p => p.State).HasColumnName("State").IsRequired(true);
            builder.Property(p => p.PostalCode).HasColumnName("PostalCode").IsRequired(true);
            builder.Property(p => p.Country).HasColumnName("Country").IsRequired(true);
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(true);
            builder.Property(p => p.Fax).HasColumnName("Fax").IsRequired(true);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(true);
            builder.Property(p => p.URL).HasColumnName("URl").IsRequired(true);
            builder.Property(p => p.PaymentMethods).HasColumnName("PaymentMethods").IsRequired(true);
            builder.Property(p => p.DiscountType).HasColumnName("DiscountType").IsRequired(true);
            builder.Property(p => p.TypeGoods).HasColumnName("TypeGoods").IsRequired(true);
            builder.Property(p => p.Notes).HasColumnName("Notes").IsRequired(true);
            builder.Property(p => p.DiscountAvailable).HasColumnName("DiscountAvailable").IsRequired(true);
            builder.Property(p => p.CurrentOrder).HasColumnName("CurrentOrder").IsRequired(true);
            builder.Property(p => p.Logo).HasColumnName("Logo").IsRequired(true);
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired(true);
            builder.Property(p => p.SizeURL).HasColumnName("SizeURL").IsRequired(true);

            builder.HasMany(m => m.ProductList).WithOne(o => o.Supplier).HasForeignKey(k => k.SupplierId);
        }
    }
}
