using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb1___LINQ.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik och tekniska produkter", "Electronics" },
                    { 2, "Produkter för hemmet och köket", "Home & Kitchen" },
                    { 3, "Kläder och accessoarer", "CLothing" },
                    { 4, "Sportutrustning och träningsprodukter", "Sports" },
                    { 5, "Böcker och litteratur", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Adress", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Storgatan 1, Stockholm", "anders@example.com", "Anders Svensson", -2274 },
                    { 2, "Kungsgatan 15, Göteborg", "emma@example.com", "Emma johansson", -3493 },
                    { 3, "Drottninggatan 8, Malmö", "lars@example.com", "Lars Nilsson", -4712 },
                    { 4, "Sveavägen 22, Uppsala", "sofia@example.com", "Sofia Lindgren", -5938 },
                    { 5, "Järntorget 5, Göteborg", "peter@example.com", "Peter Karlsson", -7162 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna Lindberg", "anna@techvision.se", "TechVision AB", -4620 },
                    { 2, "Johan Bergman", "johan@homestyle.se", "HomeStyle", -5839 },
                    { 3, "Maria Ek", "maria@fashionfirst.se", "Fashion First", -7058 },
                    { 4, "Erik Strand", "erik@sportmax.se", "SportMax", -8274 },
                    { 5, "Karl Holm", "karl@nordicelec.se", "Nordic Electronics", -9398 },
                    { 6, "Lisa Björk", "lisa@globalgadgets.se", "Global Gadgets", -9617 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11999 },
                    { 2, 2, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9798 },
                    { 3, 3, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 18999 },
                    { 4, 4, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3499 },
                    { 5, 5, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 16994 },
                    { 6, 1, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 899 },
                    { 7, 3, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2498 },
                    { 8, 2, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1598 },
                    { 9, 4, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5794 },
                    { 10, 5, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1299 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price", "StockQuantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone med 128GB lagring", "iPhone 13 Pro", 11999m, 15, 1 },
                    { 2, 1, " 4K Smart TV med HDR", "Samsung TV 55\"", 11999m, 15, 5 },
                    { 3, 1, "Trådlösa hörlurar med brusreducering", "Sony WH-1000XM4", 8999m, 8, 5 },
                    { 4, 1, "Laptop med M1-chip och 8GB RAM", "MacBook Air", 3499m, 7, 1 },
                    { 5, 1, "Automatisk espressomaskin", "Espressomaskin", 12499m, 12, 2 },
                    { 6, 2, "Multifunktionell köksmaskin", "Matberedare", 1299m, 20, 2 },
                    { 7, 3, "Varm jacka för vinterbruk", "Vinteracka", 1999m, 25, 3 },
                    { 8, 3, "Skor för distanslöpning", "Löparskor", 1499m, 18, 3 },
                    { 9, 4, "Halkfri yogamatta", "Yogamatta", 349m, 30, 4 },
                    { 10, 5, "Populär skönlitterär roman", "Bestsellerroman", 249m, 40, 2 },
                    { 11, 1, "Högpresterande dator för gaming", "Gaming PC", 18999m, 5, 6 },
                    { 12, 1, "10\" surfplatta med WiFi", "Tablet", 4299m, 9, 5 },
                    { 13, 1, "Portabel högtalare med 20h batteritid", "Bluetooth-högtalare", 899m, 22, 6 },
                    { 14, 2, "Programmerbar kaffebryggare", "Kaffebryggare", 799m, 14, 2 },
                    { 15, 3, "Funktionströja för träning", "Träningströja", 499m, 35, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 11999m },
                    { 2, 2, 3, 2, 3499m },
                    { 3, 2, 13, 2, 899m },
                    { 4, 3, 11, 1, 18999m },
                    { 5, 4, 3, 1, 3499m },
                    { 6, 5, 4, 1, 12499m },
                    { 7, 5, 5, 1, 4495m },
                    { 8, 6, 13, 1, 899m },
                    { 9, 7, 8, 1, 1499m },
                    { 10, 7, 9, 3, 349m },
                    { 11, 8, 7, 1, 1999m },
                    { 12, 8, 15, 3, 499m },
                    { 13, 9, 2, 1, 8999m },
                    { 14, 9, 6, 1, 1299m },
                    { 15, 9, 14, 2, 799m },
                    { 16, 10, 6, 1, 1299m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
