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
    public class CustomerConfigure : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(k => k.CustomerId);

            builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired(true).HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired(true).HasColumnType("text").HasMaxLength(100);
            builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired(true).HasColumnType("text").HasMaxLength(100);
            builder.Property(p => p.Address1).HasColumnName("Address1").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(true).HasColumnType("text").HasMaxLength(20);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.Password).HasColumnName("Password").IsRequired(true).HasColumnType("text").HasMaxLength(255);
            builder.Property(p => p.DateEntered).HasColumnName("DateEntered").IsRequired(true).HasColumnType("date");

            builder.HasMany(m => m.OrderList).WithOne(o => o.Customer).HasForeignKey(k => k.CustomerId);
        }
    }
}
