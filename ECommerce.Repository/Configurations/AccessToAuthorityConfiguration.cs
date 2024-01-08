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
    public class AccessToAuthorityConfiguration : IEntityTypeConfiguration<AccessToAuthority>
    {
        public void Configure(EntityTypeBuilder<AccessToAuthority> builder)
        {
            builder.HasKey(a => new
            {
                a.AccessAreaId,
                a.AuthorityId
            });

            builder.Property(a => a.Description).IsRequired(false);
            builder.Property(a => a.AddedDate).IsRequired();

            builder.HasOne(a => a.AccessAreas).WithMany(a => a.AccessToAuthority).HasForeignKey(a => a.AccessAreaId);
            builder.HasOne(a => a.Authorizations).WithMany(a => a.AccessToAuthority).HasForeignKey(a => a.AuthorityId);
        }
    }
}
