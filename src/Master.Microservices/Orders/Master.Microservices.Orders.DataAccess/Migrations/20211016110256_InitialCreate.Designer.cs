﻿// <auto-generated />
using System;
using Master.Microservices.Orders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Master.Microservices.Orders.DataAccess.Migrations
{
    [DbContext(typeof(OrderDataContext))]
    [Migration("20211016110256_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Orders", "Orders");
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", "Orders");
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", "Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8081),
                            CreatedBy = 1,
                            Description = "Laptop",
                            IsAvailable = true,
                            IsEnabled = true,
                            Name = "Laptop",
                            Price = 50000m,
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8104)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8207),
                            CreatedBy = 1,
                            Description = "Printer",
                            IsAvailable = true,
                            IsEnabled = true,
                            Name = "Printer",
                            Price = 30000m,
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8210)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8214),
                            CreatedBy = 1,
                            Description = "Laptop",
                            IsAvailable = true,
                            IsEnabled = true,
                            Name = "Scanner",
                            Price = 70000m,
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8215)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8218),
                            CreatedBy = 1,
                            Description = "Written By Sadguru",
                            IsAvailable = true,
                            IsEnabled = true,
                            Name = "Karma",
                            Price = 400m,
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8220)
                        });
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory", "Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 542, DateTimeKind.Local).AddTicks(4087),
                            CreatedBy = 1,
                            Description = "Electronics",
                            IsEnabled = true,
                            Name = "Electronics",
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(6478)
                        },
                        new
                        {
                            Id = 2,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7150),
                            CreatedBy = 1,
                            Description = "Books",
                            IsEnabled = true,
                            Name = "Books",
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7165)
                        },
                        new
                        {
                            Id = 3,
                            CreateTime = new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7183),
                            CreatedBy = 1,
                            Description = "Fashion",
                            IsEnabled = true,
                            Name = "Fashion",
                            UpdateTime = new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7185)
                        });
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.OrderItem", b =>
                {
                    b.HasOne("Master.Microservices.Orders.DataAccess.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Master.Microservices.Orders.DataAccess.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.Product", b =>
                {
                    b.HasOne("Master.Microservices.Orders.DataAccess.Models.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Master.Microservices.Orders.DataAccess.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
