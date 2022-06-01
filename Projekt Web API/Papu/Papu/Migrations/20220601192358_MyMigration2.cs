using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zelazo",
                table: "Products",
                newName: "VitaminD");

            migrationBuilder.RenameColumn(
                name: "WitaminaD",
                table: "Products",
                newName: "VitaminB12");

            migrationBuilder.RenameColumn(
                name: "WitaminaB12",
                table: "Products",
                newName: "Magnesium");

            migrationBuilder.RenameColumn(
                name: "Wapn",
                table: "Products",
                newName: "Iron");

            migrationBuilder.RenameColumn(
                name: "Magnez",
                table: "Products",
                newName: "Folate");

            migrationBuilder.RenameColumn(
                name: "Foliany",
                table: "Products",
                newName: "Calcium");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VitaminD",
                table: "Products",
                newName: "Zelazo");

            migrationBuilder.RenameColumn(
                name: "VitaminB12",
                table: "Products",
                newName: "WitaminaD");

            migrationBuilder.RenameColumn(
                name: "Magnesium",
                table: "Products",
                newName: "WitaminaB12");

            migrationBuilder.RenameColumn(
                name: "Iron",
                table: "Products",
                newName: "Wapn");

            migrationBuilder.RenameColumn(
                name: "Folate",
                table: "Products",
                newName: "Magnez");

            migrationBuilder.RenameColumn(
                name: "Calcium",
                table: "Products",
                newName: "Foliany");
        }
    }
}
