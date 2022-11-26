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

            builder.Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired(true);
            builder.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired(true);
            builder.Property(p => p.LastName).HasColumnName("LastName").IsRequired(true);
            builder.Property(p => p.Class).HasColumnName("Class").IsRequired(true);
            builder.Property(p => p.Room).HasColumnName("Room").IsRequired(true);
            builder.Property(p => p.Building).HasColumnName("Building").IsRequired(true);
            builder.Property(p => p.Address1).HasColumnName("Address1").IsRequired(true);
            builder.Property(p => p.Address2).HasColumnName("Address2").IsRequired(true);
            builder.Property(p => p.City).HasColumnName("City").IsRequired(true);
            builder.Property(p => p.State).HasColumnName("State").IsRequired(true);
            builder.Property(p => p.PostalCode).HasColumnName("PostalCode").IsRequired(true);
            builder.Property(p => p.Country).HasColumnName("Country").IsRequired(true);
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(true);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(true);
            builder.Property(p => p.VoiseMail).HasColumnName("VoiseMail").IsRequired(true);
            builder.Property(p => p.Password).HasColumnName("Password").IsRequired(true);
            builder.Property(p => p.CreditCard).HasColumnName("CreditCard").IsRequired(true);
            builder.Property(p => p.CreditCardTypeId).HasColumnName("CreditCardTypeId").IsRequired(true);
            builder.Property(p => p.CardExpMo).HasColumnName("CardExpMo").IsRequired(true);
            builder.Property(p => p.CardExpYr).HasColumnName("CardExpYr").IsRequired(true);
            builder.Property(p => p.BuildingAddress).HasColumnName("BuildingAddress").IsRequired(true);
            builder.Property(p => p.BuildingCity).HasColumnName("BuildingCity").IsRequired(true);
            builder.Property(p => p.BuildingRegion).HasColumnName("Buildingregion").IsRequired(true);
            builder.Property(p => p.BuildingPostalCode).HasColumnName("BuildingPostalCode").IsRequired(true);
            builder.Property(p => p.BuildingCountry).HasColumnName("BuildingCountry").IsRequired(true);
            builder.Property(p => p.ShipAddress).HasColumnName("ShipAddress").IsRequired(true);
            builder.Property(p => p.ShipCity).HasColumnName("ShipCity").IsRequired(true);
            builder.Property(p => p.ShipRegion).HasColumnName("ShipRegion").IsRequired(true);
            builder.Property(p => p.ShipPostalCode).HasColumnName("ShipPostalCode").IsRequired(true);
            builder.Property(p => p.ShipCountry).HasColumnName("ShipCountry").IsRequired(true);
            builder.Property(p => p.DateEntered).HasColumnName("DateEntered").IsRequired(true);

            builder.HasMany(m => m.OrderList).WithOne(o => o.Customer).HasForeignKey(k => k.CustomerId);
        }
    }
}
