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
    public class CitiesConfiguration : IEntityTypeConfiguration<Cities>
    {
        public void Configure(EntityTypeBuilder<Cities> builder)
        {
            builder.HasKey(c => c.CityCode);
            builder.Property(c => c.CityName).IsRequired().HasMaxLength(128);
        }
    }
}
