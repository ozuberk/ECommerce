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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u=>u.ID).UseIdentityColumn();
            builder.Property(u=>u.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u=>u.UserLastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.UserPicture).IsRequired(false);
            builder.Property(u => u.UserEmail).IsRequired();
            builder.Property(u => u.UserPassword).IsRequired();
            builder.Property(u => u.AnEmployee).IsRequired();

            builder.HasOne(u => u.Customers).WithOne(c => c.Users).HasForeignKey<Customers>(c => c.UserId);
            builder.HasOne(u => u.Authorizations).WithMany(a => a.Users).HasForeignKey(u => u.AuthorityId);
            builder.HasMany(u => u.Comments).WithOne(c => c.Users).HasForeignKey(c => c.UserId);
            builder.HasMany(u => u.Orders).WithOne(o => o.Users).HasForeignKey(o => o.UserId);
            builder.HasOne(u=>u.Employees).WithOne(e=>e.Users).HasForeignKey<Employees>(e => e.EmployeeUserInfoId);
        }
    }
}
