using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Products_ProductId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Menus_FridayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MondayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SaturdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SundayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ThursdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_TuesdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_WednesdayId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "Types",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "KindsOf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FridayId",
                table: "Menus",
                column: "FridayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MondayId",
                table: "Menus",
                column: "MondayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SaturdayId",
                table: "Menus",
                column: "SaturdayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SundayId",
                table: "Menus",
                column: "SundayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ThursdayId",
                table: "Menus",
                column: "ThursdayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TuesdayId",
                table: "Menus",
                column: "TuesdayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_WednesdayId",
                table: "Menus",
                column: "WednesdayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Products_ProductId",
                table: "Groups",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Products_ProductId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Menus_FridayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MondayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SaturdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_SundayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_ThursdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_TuesdayId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_WednesdayId",
                table: "Menus");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "Types",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "KindsOf",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FridayId",
                table: "Menus",
                column: "FridayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MondayId",
                table: "Menus",
                column: "MondayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SaturdayId",
                table: "Menus",
                column: "SaturdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SundayId",
                table: "Menus",
                column: "SundayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ThursdayId",
                table: "Menus",
                column: "ThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TuesdayId",
                table: "Menus",
                column: "TuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_WednesdayId",
                table: "Menus",
                column: "WednesdayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Products_ProductId",
                table: "Groups",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
