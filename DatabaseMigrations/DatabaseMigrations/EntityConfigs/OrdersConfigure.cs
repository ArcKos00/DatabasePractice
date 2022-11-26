﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.EntityConfigs
{
    public class OrdersConfigure : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderId);

            builder.Property(p => p.OrderId).HasColumnName("OrderId").IsRequired(true).ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired(true);
            builder.Property(p => p.OrderNumber).HasColumnName("OrderNumber").IsRequired(true);
            builder.Property(p => p.PaymentId).HasColumnName("PaymentId").IsRequired(true);
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate").IsRequired(true);
            builder.Property(p => p.ShipDate).HasColumnName("ShipData").IsRequired(true);
            builder.Property(p => p.RequiredDate).HasColumnName("RequiredDate").IsRequired(true);
            builder.Property(p => p.ShipperId).HasColumnName("ShipperId").IsRequired(true);
            builder.Property(p => p.Freight).HasColumnName("Freight").IsRequired(true);
            builder.Property(p => p.SailesTax).HasColumnName("SailesTax").IsRequired(true);
            builder.Property(p => p.TimeStamp).HasColumnName("TimeStamp").IsRequired(true);
            builder.Property(p => p.TransactStatus).HasColumnName("Transact").IsRequired(true);
            builder.Property(p => p.ErrLoc).HasColumnName("ErrLoc").IsRequired(true);
            builder.Property(p => p.ErrMag).HasColumnName("ReeMag").IsRequired(true);
            builder.Property(p => p.FullFilled).HasColumnName("FullFilling").IsRequired(true);
            builder.Property(p => p.Deleted).HasColumnName("Deleted").IsRequired(true);
            builder.Property(p => p.Paid).HasColumnName("Paid").IsRequired(true);
            builder.Property(p => p.PaymentDate).HasColumnName("PaymentDate").IsRequired(true);

            builder.HasOne(o => o.Customer).WithMany(m => m.OrderList).HasForeignKey(k => k.CustomerId);
            builder.HasOne(o => o.Shipper).WithMany(m => m.OrderList).HasForeignKey(k => k.ShipperId);
            builder.HasOne(o => o.Pay).WithMany(m => m.OrderList).HasForeignKey(k => k.PaymentId);
            builder.HasMany(m => m.Details).WithOne(o => o.Order).HasForeignKey(k => k.OrderId);
        }
    }
}
