﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingProject.Coupon.Database.Contexts;

#nullable disable

namespace ShoppingProject.Coupon.Database.Migrations
{
    [DbContext(typeof(CouponDbContext))]
    [Migration("20240311201502_AddSeeding")]
    partial class AddSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingProject.Coupon.Database.Entities.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("MinAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4f49c86f-09ac-4fdf-9028-5910c6fa50b7"),
                            Code = "OFF10",
                            DiscountAmount = 10.0,
                            ExpiryDate = new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MinAmount = 30.0
                        },
                        new
                        {
                            Id = new Guid("78c728dc-679f-41ad-add6-8b7a61d386b9"),
                            Code = "OFF20",
                            DiscountAmount = 20.0,
                            ExpiryDate = new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MinAmount = 60.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
