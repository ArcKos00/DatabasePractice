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
            builder.ToTable("Products");
            builder.HasKey(k => k.ProductId);

            builder.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired(true);
            builder.Property(p => p.ProductDiscription).HasColumnName("ProductDiscription").IsRequired(true);
            builder.Property(p => p.SupplierId).HasColumnName("SupplierId").IsRequired(true);
            builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired(true);
            builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired(true);
            builder.Property(p => p.Discount).HasColumnName("Discount").IsRequired(true);
            builder.Property(p => p.UnitWeight).HasColumnName("UnitWeight").IsRequired(true);
            builder.Property(p => p.ProductAvailable).HasColumnName("ProductAvailable").IsRequired(true);
            builder.Property(p => p.DiscountAvailable).HasColumnName("DiscountAvailable").IsRequired(true);
            builder.Property(p => p.CurrentOrder).HasColumnName("CurrentOrder").IsRequired(true);
            builder.Property(p => p.Picture).HasColumnName("Picture").IsRequired(true);

            builder.HasOne(o => o.Category).WithMany(m => m.ProductsList).HasForeignKey(k => k.CategoryId);
            builder.HasOne(o => o.Supplier).WithMany(m => m.ProductList).HasForeignKey(k => k.SupplierId);
            builder.HasMany(m => m.Details).WithOne(o => o.Product).HasForeignKey(k => k.ProductId);
        }
    }
}
