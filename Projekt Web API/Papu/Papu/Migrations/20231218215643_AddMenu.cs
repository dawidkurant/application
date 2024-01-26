using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papu.Migrations
{
    public partial class AddMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "DaysMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysMenu_MenuId",
                table: "DaysMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedById",
                table: "Menus",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysMenu_Menus_MenuId",
                table: "DaysMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysMenu_Menus_MenuId",
                table: "DaysMenu");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_DaysMenu_MenuId",
                table: "DaysMenu");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "DaysMenu");
        }
    }
}
