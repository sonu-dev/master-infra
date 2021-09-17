using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Microservices.Catalog.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 1, new DateTime(2021, 9, 18, 0, 9, 19, 414, DateTimeKind.Local).AddTicks(5905), 1, "Electronics", true, "Electronics", new DateTime(2021, 9, 18, 0, 9, 19, 415, DateTimeKind.Local).AddTicks(7795) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 2, new DateTime(2021, 9, 18, 0, 9, 19, 415, DateTimeKind.Local).AddTicks(8367), 1, "Books", true, "Books", new DateTime(2021, 9, 18, 0, 9, 19, 415, DateTimeKind.Local).AddTicks(8382) });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 3, new DateTime(2021, 9, 18, 0, 9, 19, 415, DateTimeKind.Local).AddTicks(8430), 1, "Fashion", true, "Fashion", new DateTime(2021, 9, 18, 0, 9, 19, 415, DateTimeKind.Local).AddTicks(8431) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateTime", "CreatedBy", "Description", "IsAvailable", "IsEnabled", "Name", "Price", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8486), 1, "Laptop", true, true, "Laptop", 50000m, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8505) },
                    { 2, 1, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8592), 1, "Printer", true, true, "Printer", 30000m, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8594) },
                    { 3, 1, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8597), 1, "Laptop", true, true, "Scanner", 70000m, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8599) },
                    { 4, 2, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8601), 1, "Written By Sadguru", true, true, "Karma", 400m, new DateTime(2021, 9, 18, 0, 9, 19, 417, DateTimeKind.Local).AddTicks(8603) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
