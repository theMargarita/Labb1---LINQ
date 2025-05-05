using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb1___LINQ.Migrations
{
    /// <inheritdoc />
    public partial class newChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "SupplierId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "SupplierId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_SupplierId",
                table: "Categories",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_Suppliers_SupplierId",
                table: "Categories",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_Suppliers_SupplierId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categorys_SupplierId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Categories");
        }
    }
}
