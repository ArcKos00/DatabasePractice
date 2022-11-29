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
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(true);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(true);

            builder.HasMany(m => m.ProductList).WithOne(o => o.Supplier).HasForeignKey(k => k.SupplierId);
        }
    }
}
