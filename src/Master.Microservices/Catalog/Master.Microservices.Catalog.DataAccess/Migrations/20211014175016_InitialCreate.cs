using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Microservices.Orders.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 1, new DateTime(2021, 10, 14, 23, 20, 15, 872, DateTimeKind.Local).AddTicks(4800), 1, "Electronics", true, "Electronics", new DateTime(2021, 10, 14, 23, 20, 15, 873, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 2, new DateTime(2021, 10, 14, 23, 20, 15, 873, DateTimeKind.Local).AddTicks(7896), 1, "Books", true, "Books", new DateTime(2021, 10, 14, 23, 20, 15, 873, DateTimeKind.Local).AddTicks(7911) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 3, new DateTime(2021, 10, 14, 23, 20, 15, 873, DateTimeKind.Local).AddTicks(7930), 1, "Fashion", true, "Fashion", new DateTime(2021, 10, 14, 23, 20, 15, 873, DateTimeKind.Local).AddTicks(7931) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateTime", "CreatedBy", "Description", "IsAvailable", "IsEnabled", "Name", "Price", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8666), 1, "Laptop", true, true, "Laptop", 50000m, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8690) },
                    { 2, 1, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8781), 1, "Printer", true, true, "Printer", 30000m, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8783) },
                    { 3, 1, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8787), 1, "Laptop", true, true, "Scanner", 70000m, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8788) },
                    { 4, 2, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8791), 1, "Written By Sadguru", true, true, "Karma", 400m, new DateTime(2021, 10, 14, 23, 20, 15, 875, DateTimeKind.Local).AddTicks(8792) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
