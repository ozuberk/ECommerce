﻿// <auto-generated />
using System;
using ECommerce.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240107195038_last_edit")]
    partial class lastedit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.AccessAreas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccessAuthorityId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ControllerName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ViewName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("ID");

                    b.ToTable("AccessAreas");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.AccessToAuthority", b =>
                {
                    b.Property<int>("AuthorityId")
                        .HasColumnType("int");

                    b.Property<int>("AccessAreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorityId");

                    b.HasIndex("AccessAreaId");

                    b.ToTable("AccessToAuthority");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Addresses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AddressTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictCode")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DistrictCode");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Authorizations", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuthorityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Categories", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Cities", b =>
                {
                    b.Property<int>("CityCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityCode"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("CityCode");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Comments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CommentTopId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("50");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Districts", b =>
                {
                    b.Property<int>("DistrictCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictCode"));

                    b.Property<int>("CityCode")
                        .HasColumnType("int");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("DistrictCode");

                    b.HasIndex("CityCode");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Employees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AboutTheEmployee")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("EmployeeSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("EmployeeUserInfoID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeUserInfoId")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LivesInACity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MaritalStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SalaryPayDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeUserInfoID");

                    b.HasIndex("EmployeeUserInfoId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Menus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AccessAreaId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MenuOrder")
                        .HasColumnType("int");

                    b.Property<int?>("TopMenuId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccessAreaId")
                        .IsUnique();

                    b.HasIndex("TopMenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Orders", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalProductQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Pictures", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PictureDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("PictureOrder")
                        .HasColumnType("tinyint");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("AnEmployee")
                        .HasColumnType("bit");

                    b.Property<int>("AuthorityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.AccessToAuthority", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.AccessAreas", "AccessAreas")
                        .WithMany("AccessToAuthority")
                        .HasForeignKey("AccessAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Authorizations", "Authorizations")
                        .WithMany("AccessToAuthority")
                        .HasForeignKey("AuthorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessAreas");

                    b.Navigation("Authorizations");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Addresses", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Customers", "Customers")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Districts", "Districts")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Comments", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Products", "Products")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Users", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");

                    b.Navigation("Products");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Customers", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Users", "Users")
                        .WithOne("Customers")
                        .HasForeignKey("ECommerce.Core.ECommerceDatabase.Customers", "UserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Districts", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Cities", "Cities")
                        .WithMany("Districts")
                        .HasForeignKey("CityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Employees", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Users", "EmployeeUserInfo")
                        .WithMany()
                        .HasForeignKey("EmployeeUserInfoID");

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Users", "Users")
                        .WithOne("Employees")
                        .HasForeignKey("ECommerce.Core.ECommerceDatabase.Employees", "EmployeeUserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeUserInfo");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Menus", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.AccessAreas", "AccessAreas")
                        .WithOne("Menus")
                        .HasForeignKey("ECommerce.Core.ECommerceDatabase.Menus", "AccessAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Menus", "TopMenu")
                        .WithMany("SubMenu")
                        .HasForeignKey("TopMenuId");

                    b.Navigation("AccessAreas");

                    b.Navigation("TopMenu");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.OrderDetails", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Products", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Orders", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Core.ECommerceDatabase.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("Customers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Pictures", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Products", "Products")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Products", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Users", b =>
                {
                    b.HasOne("ECommerce.Core.ECommerceDatabase.Authorizations", "Authorizations")
                        .WithMany("Users")
                        .HasForeignKey("AuthorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authorizations");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.AccessAreas", b =>
                {
                    b.Navigation("AccessToAuthority");

                    b.Navigation("Menus");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Authorizations", b =>
                {
                    b.Navigation("AccessToAuthority");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Cities", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Customers", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Districts", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Menus", b =>
                {
                    b.Navigation("SubMenu");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Products", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("OrderDetails");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("ECommerce.Core.ECommerceDatabase.Users", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
