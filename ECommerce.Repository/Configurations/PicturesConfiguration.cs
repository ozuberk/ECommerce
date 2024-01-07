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
    public class PicturesConfiguration : IEntityTypeConfiguration<Pictures>
    {
        public void Configure(EntityTypeBuilder<Pictures> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).UseIdentityColumn();
            builder.Property(p => p.Active).IsRequired(true);
            builder.Property(p => p.AddedDate).IsRequired(true);
            builder.Property(p => p.PicturePath).IsRequired(true);
            builder.Property(p => p.PictureDescription).IsRequired(true);
            builder.Property(p => p.PictureOrder).IsRequired(false).HasColumnType("tinyint");

            builder.HasOne(p => p.Products).WithMany(pi => pi.Pictures).HasForeignKey(p => p.ProductId)
        }
    }
}
