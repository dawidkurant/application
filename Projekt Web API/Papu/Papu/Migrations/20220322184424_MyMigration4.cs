using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Wednesdays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Tuesdays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Thursdays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Sundays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Snacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "SecondBreakfasts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Saturdays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Mondays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Lunches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Fridays",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Dinners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Breakfasts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_CreatedById",
                table: "Wednesdays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_CreatedById",
                table: "Tuesdays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_CreatedById",
                table: "Thursdays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_CreatedById",
                table: "Sundays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_CreatedById",
                table: "Snacks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SecondBreakfasts_CreatedById",
                table: "SecondBreakfasts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_CreatedById",
                table: "Saturdays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_CreatedById",
                table: "Mondays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedById",
                table: "Menus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lunches_CreatedById",
                table: "Lunches",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_CreatedById",
                table: "Fridays",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CreatedById",
                table: "Dishes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dinners_CreatedById",
                table: "Dinners",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Breakfasts_CreatedById",
                table: "Breakfasts",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakfasts_Users_CreatedById",
                table: "Breakfasts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dinners_Users_CreatedById",
                table: "Dinners",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Users_CreatedById",
                table: "Dishes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fridays_Users_CreatedById",
                table: "Fridays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lunches_Users_CreatedById",
                table: "Lunches",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Users_CreatedById",
                table: "Menus",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mondays_Users_CreatedById",
                table: "Mondays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saturdays_Users_CreatedById",
                table: "Saturdays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondBreakfasts_Users_CreatedById",
                table: "SecondBreakfasts",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Snacks_Users_CreatedById",
                table: "Snacks",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sundays_Users_CreatedById",
                table: "Sundays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Thursdays_Users_CreatedById",
                table: "Thursdays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tuesdays_Users_CreatedById",
                table: "Tuesdays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wednesdays_Users_CreatedById",
                table: "Wednesdays",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakfasts_Users_CreatedById",
                table: "Breakfasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Dinners_Users_CreatedById",
                table: "Dinners");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Users_CreatedById",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Fridays_Users_CreatedById",
                table: "Fridays");

            migrationBuilder.DropForeignKey(
                name: "FK_Lunches_Users_CreatedById",
                table: "Lunches");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Users_CreatedById",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Mondays_Users_CreatedById",
                table: "Mondays");

            migrationBuilder.DropForeignKey(
                name: "FK_Saturdays_Users_CreatedById",
                table: "Saturdays");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondBreakfasts_Users_CreatedById",
                table: "SecondBreakfasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Snacks_Users_CreatedById",
                table: "Snacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Sundays_Users_CreatedById",
                table: "Sundays");

            migrationBuilder.DropForeignKey(
                name: "FK_Thursdays_Users_CreatedById",
                table: "Thursdays");

            migrationBuilder.DropForeignKey(
                name: "FK_Tuesdays_Users_CreatedById",
                table: "Tuesdays");

            migrationBuilder.DropForeignKey(
                name: "FK_Wednesdays_Users_CreatedById",
                table: "Wednesdays");

            migrationBuilder.DropIndex(
                name: "IX_Wednesdays_CreatedById",
                table: "Wednesdays");

            migrationBuilder.DropIndex(
                name: "IX_Tuesdays_CreatedById",
                table: "Tuesdays");

            migrationBuilder.DropIndex(
                name: "IX_Thursdays_CreatedById",
                table: "Thursdays");

            migrationBuilder.DropIndex(
                name: "IX_Sundays_CreatedById",
                table: "Sundays");

            migrationBuilder.DropIndex(
                name: "IX_Snacks_CreatedById",
                table: "Snacks");

            migrationBuilder.DropIndex(
                name: "IX_SecondBreakfasts_CreatedById",
                table: "SecondBreakfasts");

            migrationBuilder.DropIndex(
                name: "IX_Saturdays_CreatedById",
                table: "Saturdays");

            migrationBuilder.DropIndex(
                name: "IX_Mondays_CreatedById",
                table: "Mondays");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CreatedById",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Lunches_CreatedById",
                table: "Lunches");

            migrationBuilder.DropIndex(
                name: "IX_Fridays_CreatedById",
                table: "Fridays");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CreatedById",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dinners_CreatedById",
                table: "Dinners");

            migrationBuilder.DropIndex(
                name: "IX_Breakfasts_CreatedById",
                table: "Breakfasts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Wednesdays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tuesdays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Thursdays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Sundays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SecondBreakfasts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Saturdays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Mondays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Lunches");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Fridays");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Breakfasts");
        }
    }
}
