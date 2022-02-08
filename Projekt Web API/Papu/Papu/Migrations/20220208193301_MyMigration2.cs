using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Fridays_FridayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Mondays_MondayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Saturdays_SaturdayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Sundays_SundayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Thursdays_ThursdayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Tuesdays_TuesdayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Wednesdays_WednesdayId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Fridays_FridayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Mondays_MondayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Saturdays_SaturdayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sundays_SundayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Thursdays_ThursdayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tuesdays_TuesdayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Wednesdays_WednesdayId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Products_FridayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MondayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SaturdayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SundayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ThursdayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TuesdayId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WednesdayId",
                table: "Products");

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

            migrationBuilder.DropIndex(
                name: "IX_Dishes_FridayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_MondayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_SaturdayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_SundayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ThursdayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_TuesdayId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_WednesdayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "FridayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MondayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaturdayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SundayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThursdayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TuesdayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WednesdayId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FridayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "MondayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "SaturdayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "SundayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ThursdayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "TuesdayId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "WednesdayId",
                table: "Dishes");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types");

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
                name: "DishId",
                table: "Types",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MondayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SundayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "KindsOf",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FridayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MondayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaturdayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SundayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThursdayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TuesdayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WednesdayId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FridayId",
                table: "Products",
                column: "FridayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MondayId",
                table: "Products",
                column: "MondayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SaturdayId",
                table: "Products",
                column: "SaturdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SundayId",
                table: "Products",
                column: "SundayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ThursdayId",
                table: "Products",
                column: "ThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TuesdayId",
                table: "Products",
                column: "TuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WednesdayId",
                table: "Products",
                column: "WednesdayId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_FridayId",
                table: "Dishes",
                column: "FridayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MondayId",
                table: "Dishes",
                column: "MondayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_SaturdayId",
                table: "Dishes",
                column: "SaturdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_SundayId",
                table: "Dishes",
                column: "SundayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ThursdayId",
                table: "Dishes",
                column: "ThursdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_TuesdayId",
                table: "Dishes",
                column: "TuesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_WednesdayId",
                table: "Dishes",
                column: "WednesdayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Fridays_FridayId",
                table: "Dishes",
                column: "FridayId",
                principalTable: "Fridays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Mondays_MondayId",
                table: "Dishes",
                column: "MondayId",
                principalTable: "Mondays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Saturdays_SaturdayId",
                table: "Dishes",
                column: "SaturdayId",
                principalTable: "Saturdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Sundays_SundayId",
                table: "Dishes",
                column: "SundayId",
                principalTable: "Sundays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Thursdays_ThursdayId",
                table: "Dishes",
                column: "ThursdayId",
                principalTable: "Thursdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Tuesdays_TuesdayId",
                table: "Dishes",
                column: "TuesdayId",
                principalTable: "Tuesdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Wednesdays_WednesdayId",
                table: "Dishes",
                column: "WednesdayId",
                principalTable: "Wednesdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KindsOf_Dishes_DishId",
                table: "KindsOf",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Fridays_FridayId",
                table: "Products",
                column: "FridayId",
                principalTable: "Fridays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Mondays_MondayId",
                table: "Products",
                column: "MondayId",
                principalTable: "Mondays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Saturdays_SaturdayId",
                table: "Products",
                column: "SaturdayId",
                principalTable: "Saturdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sundays_SundayId",
                table: "Products",
                column: "SundayId",
                principalTable: "Sundays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Thursdays_ThursdayId",
                table: "Products",
                column: "ThursdayId",
                principalTable: "Thursdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tuesdays_TuesdayId",
                table: "Products",
                column: "TuesdayId",
                principalTable: "Tuesdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Wednesdays_WednesdayId",
                table: "Products",
                column: "WednesdayId",
                principalTable: "Wednesdays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Dishes_DishId",
                table: "Types",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
