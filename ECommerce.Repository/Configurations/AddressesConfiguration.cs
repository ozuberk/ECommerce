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
    public class AddressesConfiguration : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityColumn();
            builder.Property(a => a.AddressTitle).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Address).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PostCode).IsRequired(false);

            builder.HasOne(a => a.Districts).WithMany(d => d.Addresses).HasForeignKey(a => a.DistrictCode);
            builder.HasOne(a => a.Customers).WithMany(c => c.Addresses).HasForeignKey(a => a.CustomerId);

        }
    }
}
