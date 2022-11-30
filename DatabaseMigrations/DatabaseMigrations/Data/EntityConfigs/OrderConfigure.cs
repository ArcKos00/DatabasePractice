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
    public class OrderConfigure : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderId);

            builder.Property(p => p.OrderId).HasColumnName("OrderId").IsRequired(true).HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.OrderNumber).HasColumnName("OrderNumber").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.PaymentId).HasColumnName("PaymentId").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate").IsRequired(true).HasColumnType("date");
            builder.Property(p => p.ShipperId).HasColumnName("ShipperId").IsRequired(true).HasColumnType("int");
            builder.Property(p => p.Paid).HasColumnName("Paid").IsRequired(true).HasColumnType("bool");

            builder.HasOne(o => o.Customer).WithMany(m => m.OrderList).HasForeignKey(k => k.CustomerId);
            builder.HasOne(o => o.Shipper).WithMany(m => m.OrderList).HasForeignKey(k => k.ShipperId);
            builder.HasOne(o => o.Pay).WithMany(m => m.OrderList).HasForeignKey(k => k.PaymentId);
            builder.HasMany(m => m.Details).WithOne(o => o.Order).HasForeignKey(k => k.OrderDetailId);
        }
    }
}
