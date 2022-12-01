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
    public class ProductConfigure : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.ProductName).HasMaxLength(255);
            builder.Property(p => p.ProductDiscription).HasMaxLength(255);
            builder.Property(p => p.SupplierId);
            builder.Property(p => p.CategoryId);
            builder.Property(p => p.UnitPrice);
            builder.Property(p => p.Discount);
            builder.Property(p => p.ProductAvailable);
            builder.Property(p => p.CurrentOrder);

            builder.HasOne(o => o.Category).WithMany(m => m.ProductsList).HasForeignKey(k => k.CategoryId);
            builder.HasOne(o => o.Supplier).WithMany(m => m.ProductList).HasForeignKey(k => k.SupplierId);
            builder.HasMany(m => m.Details).WithOne(o => o.Product).HasForeignKey(k => k.ProductId);
        }
    }
}
