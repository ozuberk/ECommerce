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
    public class DistrictsConfiguration : IEntityTypeConfiguration<Districts>
    {
        public void Configure(EntityTypeBuilder<Districts> builder)
        {
            builder.HasKey(d => d.DistrictCode);
            builder.Property(d => d.DistrictCode).IsRequired();
            builder.Property(d => d.DistrictName).IsRequired().HasMaxLength(128);

            builder.HasOne(d => d.Cities).WithMany(c => c.Districts).HasForeignKey(d => d.CityCode);
        }
    }
}
