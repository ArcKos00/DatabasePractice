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
    public class CategoryConfigure : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(k => k.CategoryId);

            builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired(true);
            builder.Property(p => p.CategoryName).HasColumnName("CategoryName").IsRequired(true);
            builder.Property(p => p.Discription).HasColumnName("Discription").IsRequired(true);
            builder.Property(p => p.Picture).HasColumnName("Picture").IsRequired(true);
            builder.Property(p => p.Active).HasColumnName("Active").IsRequired(true);

            builder.HasMany(m => m.ProductsList).WithOne(o => o.Category).HasForeignKey(k => k.CategoryId);
        }
    }
}
