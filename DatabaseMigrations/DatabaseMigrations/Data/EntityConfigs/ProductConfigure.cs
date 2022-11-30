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

            builder.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired(true).HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.ProductName).HasColumnName("ProductName").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.ProductDiscription).HasColumnName("ProductDiscription").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.SupplierId).HasColumnName("SupplierId").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired(true).HasColumnType("float8");
            builder.Property(p => p.Discount).HasColumnName("Discount").IsRequired(true).HasColumnType("float8");
            builder.Property(p => p.ProductAvailable).HasColumnName("ProductAvailable").IsRequired(true).HasColumnType("bool");
            builder.Property(p => p.CurrentOrder).HasColumnName("CurrentOrder").IsRequired(true).HasColumnType("int");

            builder.HasOne(o => o.Category).WithMany(m => m.ProductsList).HasForeignKey(k => k.CategoryId);
            builder.HasOne(o => o.Supplier).WithMany(m => m.ProductList).HasForeignKey(k => k.SupplierId);
            builder.HasMany(m => m.Details).WithOne(o => o.Product).HasForeignKey(k => k.ProductId);
        }
    }
}
