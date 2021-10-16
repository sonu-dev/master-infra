using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Microservices.Orders.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Orders",
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
                name: "ProductCategory",
                schema: "Orders",
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
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Orders",
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
                        name: "FK_Products_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Orders",
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Orders",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Orders",
                table: "ProductCategory",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 1, new DateTime(2021, 10, 16, 16, 32, 55, 542, DateTimeKind.Local).AddTicks(4087), 1, "Electronics", true, "Electronics", new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(6478) });

            migrationBuilder.InsertData(
                schema: "Orders",
                table: "ProductCategory",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 2, new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7150), 1, "Books", true, "Books", new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.InsertData(
                schema: "Orders",
                table: "ProductCategory",
                columns: new[] { "Id", "CreateTime", "CreatedBy", "Description", "IsEnabled", "Name", "UpdateTime" },
                values: new object[] { 3, new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7183), 1, "Fashion", true, "Fashion", new DateTime(2021, 10, 16, 16, 32, 55, 543, DateTimeKind.Local).AddTicks(7185) });

            migrationBuilder.InsertData(
                schema: "Orders",
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreateTime", "CreatedBy", "Description", "IsAvailable", "IsEnabled", "Name", "Price", "UpdateTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8081), 1, "Laptop", true, true, "Laptop", 50000m, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8104) },
                    { 2, 1, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8207), 1, "Printer", true, true, "Printer", 30000m, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8210) },
                    { 3, 1, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8214), 1, "Laptop", true, true, "Scanner", 70000m, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8215) },
                    { 4, 2, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8218), 1, "Written By Sadguru", true, true, "Karma", 400m, new DateTime(2021, 10, 16, 16, 32, 55, 545, DateTimeKind.Local).AddTicks(8220) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "Orders",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                schema: "Orders",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Orders",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Orders");
        }
    }
}
