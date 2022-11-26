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
    public class PaymentConfigure : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(k => k.PaymentId);

            builder.Property(p => p.PaymentId).HasColumnName("PaymentId").IsRequired(true);
            builder.Property(p => p.PaymentType).HasColumnName("PaymentType").IsRequired(true);
            builder.Property(p => p.Allowed).HasColumnName("Allowed").IsRequired(true);

            builder.HasMany(m => m.OrderList).WithOne(o => o.Pay).HasForeignKey(k => k.PaymentId);
        }
    }
}
