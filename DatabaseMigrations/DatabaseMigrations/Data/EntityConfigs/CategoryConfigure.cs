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
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.CategoryName).HasMaxLength(100);
            builder.Property(p => p.Discription).HasMaxLength(255);
            builder.Property(p => p.Active);

            builder.HasMany(m => m.ProductsList).WithOne(o => o.Category).HasForeignKey(k => k.CategoryId);
        }
    }
}
