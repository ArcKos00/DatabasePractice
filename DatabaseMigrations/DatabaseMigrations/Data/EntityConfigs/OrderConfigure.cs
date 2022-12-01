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
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.CustomerId);
            builder.Property(p => p.OrderNumber);
            builder.Property(p => p.PaymentId);
            builder.Property(p => p.OrderDate);
            builder.Property(p => p.ShipperId);
            builder.Property(p => p.Paid);

            builder.HasOne(o => o.Customer).WithMany(m => m.OrderList).HasForeignKey(k => k.CustomerId);
            builder.HasOne(o => o.Shipper).WithMany(m => m.OrderList).HasForeignKey(k => k.ShipperId);
            builder.HasOne(o => o.Pay).WithMany(m => m.OrderList).HasForeignKey(k => k.PaymentId);
            builder.HasMany(m => m.Details).WithOne(o => o.Order).HasForeignKey(k => k.Id);
        }
    }
}
