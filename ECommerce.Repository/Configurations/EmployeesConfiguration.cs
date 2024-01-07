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
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ID).UseIdentityColumn();
            builder.Property(e => e.EmployeeName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.EmployeeLastName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.EmployeeSalary).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.SalaryPayDate).IsRequired();
            builder.Property(e => e.CompanyName).IsRequired();
            builder.Property(e => e.AboutTheEmployee).IsRequired().HasMaxLength(200);
            builder.Property(e=>e.LivesInACity).IsRequired();
        }
    }
}
