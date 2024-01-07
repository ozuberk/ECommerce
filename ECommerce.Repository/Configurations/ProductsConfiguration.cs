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
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).UseIdentityColumn();
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.ProductPrice).IsRequired(true).HasColumnType("decimal(18,2");

            builder.HasOne(p => p.Categories).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasMany(p => p.OrderDetails).WithOne(od => od.Products).HasForeignKey(od => od.ProductId);
            builder.HasMany(p => p.Comments).WithOne(c => c.Products).HasForeignKey(c => c.ProductId);
            builder.HasMany(p => p.Pictures).WithOne(pi => pi.Products).HasForeignKey(pi => pi.ProductId);
        }
    }
}
