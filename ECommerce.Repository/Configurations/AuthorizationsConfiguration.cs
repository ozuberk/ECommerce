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
    public class AuthorizationsConfiguration : IEntityTypeConfiguration<Authorizations>
    {
        public void Configure(EntityTypeBuilder<Authorizations> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityColumn();
            builder.Property(a => a.Active).IsRequired();
            builder.Property(a => a.AuthorityName).IsRequired().HasMaxLength(100);

        }
    }
}
