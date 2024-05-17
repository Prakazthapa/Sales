﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales.Data;

#nullable disable

namespace Sales.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    [Migration("20240510091523_Noo")]
    partial class Noo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sales.Models.Customer", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"));

                    b.Property<string>("CAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Sales.Models.Order", b =>
                {
                    b.Property<int>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ODateTime")
                        .HasColumnType("date");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OId");

                    b.HasIndex("CId");

                    b.HasIndex("PId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Sales.Models.OrderDetails", b =>
                {
                    b.Property<int>("ODId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ODId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ODate")
                        .HasColumnType("date");

                    b.Property<int>("OId")
                        .HasColumnType("int");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("qantity")
                        .HasColumnType("int");

                    b.HasKey("ODId");

                    b.HasIndex("CId");

                    b.HasIndex("OId");

                    b.HasIndex("PId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Sales.Models.Product", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<string>("PDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("PId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Sales.Models.SerialNumber", b =>
                {
                    b.Property<int>("SerialNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SerialNumberId"));

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<string>("Serialno")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("stock")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("SerialNumberId");

                    b.HasIndex("PId");

                    b.HasIndex("Serialno")
                        .IsUnique();

                    b.ToTable("SerialNumbers");
                });

            modelBuilder.Entity("Sales.Models.Order", b =>
                {
                    b.HasOne("Sales.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Sales.Models.OrderDetails", b =>
                {
                    b.HasOne("Sales.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Sales.Models.SerialNumber", b =>
                {
                    b.HasOne("Sales.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}