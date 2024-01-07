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
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(o => o.OrderDetailId);
            builder.Property(o => o.OrderDetailId).IsRequired();
            builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.ProductId).IsRequired();
            builder.Property(o => o.ProductQuantity).IsRequired();
            builder.Property(o => o.UnitPrice).IsRequired();
        }
    }
}
