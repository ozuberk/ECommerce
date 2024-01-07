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
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.Description).IsRequired(false);
            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
        }
    }
}
