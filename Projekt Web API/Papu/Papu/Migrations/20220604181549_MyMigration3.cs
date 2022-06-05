using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AssimilableCarbohydrates",
                table: "Products",
                type: "decimal(7,2)",
                maxLength: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CarbohydrateReplacement",
                table: "Products",
                type: "decimal(7,2)",
                maxLength: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "Products",
                type: "decimal(7,2)",
                maxLength: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fiber",
                table: "Products",
                type: "decimal(7,2)",
                maxLength: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Products",
                type: "decimal(7,2)",
                maxLength: 8,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssimilableCarbohydrates",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CarbohydrateReplacement",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fiber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Products");
        }
    }
}
