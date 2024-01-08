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
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID).UseIdentityColumn();
            builder.Property(o => o.AddedDate).IsRequired();
            builder.Property(o => o.TotalProductQuantity).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(o => o.CustomerId).IsRequired();

            builder.HasMany(o => o.OrderDetails).WithOne(od => od.Orders).HasForeignKey(od => od.OrderId);
        }
    }
}
