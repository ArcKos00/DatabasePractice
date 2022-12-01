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
    public class PaymentConfigure : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.PaymentType).HasMaxLength(255);
            builder.Property(p => p.Allowed);

            builder.HasMany(m => m.OrderList).WithOne(o => o.Pay).HasForeignKey(k => k.PaymentId);
        }
    }
}
