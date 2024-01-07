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
    public class CommentsConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.Comment).IsRequired().HasMaxLength(250);
            builder.Property(c => c.AddedDate).IsRequired(true);

        }
    }
}
