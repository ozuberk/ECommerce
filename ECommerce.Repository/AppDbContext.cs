using ECommerce.Core.ECommerceDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AccessAreas> AccessAreas { get; set; }
        public DbSet<AccessToAuthority> AccessToAuthority { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Authorizations> Authorizations { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }
}
