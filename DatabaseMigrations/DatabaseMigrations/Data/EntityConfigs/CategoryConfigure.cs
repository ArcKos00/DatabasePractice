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
    public class CategoryConfigure : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(k => k.CategoryId);

            builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired(true).HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.CategoryName).HasColumnName("CategoryName").IsRequired(true).HasColumnType("text").HasMaxLength(100);
            builder.Property(p => p.Discription).HasColumnName("Discription").IsRequired(false).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.Active).HasColumnName("Active").IsRequired(true).HasColumnType("bool");

            builder.HasMany(m => m.ProductsList).WithOne(o => o.Category).HasForeignKey(k => k.CategoryId);
        }
    }
}
