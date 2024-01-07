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
    public class AccessAreasConfiguration : IEntityTypeConfiguration<AccessAreas>
    {
        public void Configure(EntityTypeBuilder<AccessAreas> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityColumn();
            builder.Property(a => a.Active).IsRequired();
            builder.Property(a => a.ControllerName).IsRequired().HasMaxLength(128);
            builder.Property(a => a.ViewName).IsRequired().HasMaxLength(128);
            builder.Property(a => a.Description).IsRequired(false);

            builder.HasOne(a => a.Menus).WithOne(m => m.AccessAreas).HasForeignKey<Menus>(m=>m.AccessAreaId);

        }
    }
}
