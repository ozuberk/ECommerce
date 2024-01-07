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
    public class MenusConfiguration : IEntityTypeConfiguration<Menus>
    {
        public void Configure(EntityTypeBuilder<Menus> builder)
        {
            builder.HasKey(m => m.ID);
            builder.Property(m => m.ID).UseIdentityColumn();
            builder.Property(m => m.MenuName).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Description).IsRequired(false);

            builder.HasOne(m => m.TopMenu).WithMany(m => m.SubMenu).HasForeignKey(m => m.TopMenuId);
        }
    }
}
