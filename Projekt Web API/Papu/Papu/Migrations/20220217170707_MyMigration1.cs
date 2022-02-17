using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Units",
                newName: "UnitName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Types",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Menus",
                newName: "MenuName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Menus",
                newName: "MenuDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "KindsOf",
                newName: "KindOfName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dishes",
                newName: "DishName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Dishes",
                newName: "DishDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitName",
                table: "Units",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "Types",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MenuName",
                table: "Menus",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MenuDescription",
                table: "Menus",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "KindOfName",
                table: "KindsOf",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DishName",
                table: "Dishes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DishDescription",
                table: "Dishes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");
        }
    }
}
