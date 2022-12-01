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
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.CompanyName).HasMaxLength(255);
            builder.Property(p => p.ContactFName).HasMaxLength(255);
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(255);

            builder.HasMany(m => m.ProductList).WithOne(o => o.Supplier).HasForeignKey(k => k.SupplierId);
        }
    }
}
