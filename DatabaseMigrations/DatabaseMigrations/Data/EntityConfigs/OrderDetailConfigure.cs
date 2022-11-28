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
    public class OrderDetailConfigure : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(k => k.OrderDetailId);

            builder.Property(p => p.OrderDetailId).HasColumnName("OrderDetailId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(p => p.OrderId).HasColumnName("OrderId").IsRequired(true);
            builder.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired(true);
            builder.Property(p => p.OrderNumber).HasColumnName("OrderNumber").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(p => p.Price).HasColumnName("Price").IsRequired(true);
            builder.Property(p => p.Discount).HasColumnName("Discount").IsRequired(true);
            builder.Property(p => p.Total).HasColumnName("Total").IsRequired(true);
            builder.Property(p => p.ShipDate).HasColumnName("ShipDate").IsRequired(true);
            builder.Property(p => p.BillDate).HasColumnName("BillDate").IsRequired(true);

            builder.HasOne(o => o.Order).WithMany(m => m.Details).HasForeignKey(k => k.OrderNumber);
            builder.HasOne(o => o.Product).WithMany(m => m.Details).HasForeignKey(k => k.OrderNumber);
        }
    }
}
