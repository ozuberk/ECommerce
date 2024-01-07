using ECommerce.Core.ECommerceDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Configurations
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CustomerLastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Gender).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Profession).IsRequired().HasDefaultValue(50);
            builder.Property(c => c.DateOfBirth).IsRequired();

            builder.HasMany(c => c.Orders).WithOne(o => o.Customers).HasForeignKey(o => o.CustomerId);
        }
    }
}
