using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingProject.Coupon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "DiscountAmount", "ExpiryDate", "MinAmount" },
                values: new object[,]
                {
                    { new Guid("4f49c86f-09ac-4fdf-9028-5910c6fa50b7"), "OFF10", 10.0, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { new Guid("78c728dc-679f-41ad-add6-8b7a61d386b9"), "OFF20", 20.0, new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("4f49c86f-09ac-4fdf-9028-5910c6fa50b7"));

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("78c728dc-679f-41ad-add6-8b7a61d386b9"));
        }
    }
}
