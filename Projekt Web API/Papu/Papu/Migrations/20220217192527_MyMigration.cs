using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Fridays",
                columns: table => new
                {
                    FridayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridays", x => x.FridayId);
                });

            migrationBuilder.CreateTable(
                name: "Mondays",
                columns: table => new
                {
                    MondayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mondays", x => x.MondayId);
                });

            migrationBuilder.CreateTable(
                name: "Saturdays",
                columns: table => new
                {
                    SaturdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturdays", x => x.SaturdayId);
                });

            migrationBuilder.CreateTable(
                name: "Sundays",
                columns: table => new
                {
                    SundayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sundays", x => x.SundayId);
                });

            migrationBuilder.CreateTable(
                name: "Thursdays",
                columns: table => new
                {
                    ThursdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thursdays", x => x.ThursdayId);
                });

            migrationBuilder.CreateTable(
                name: "Tuesdays",
                columns: table => new
                {
                    TuesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuesdays", x => x.TuesdayId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Wednesdays",
                columns: table => new
                {
                    WednesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wednesdays", x => x.WednesdayId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DishDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MethodOfPeparation = table.Column<string>(type: "nvarchar(1300)", maxLength: 1300, nullable: false),
                    Portions = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    PreparationTime = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Size = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    FridayId = table.Column<int>(type: "int", nullable: true),
                    MondayId = table.Column<int>(type: "int", nullable: true),
                    SaturdayId = table.Column<int>(type: "int", nullable: true),
                    SundayId = table.Column<int>(type: "int", nullable: true),
                    ThursdayId = table.Column<int>(type: "int", nullable: true),
                    TuesdayId = table.Column<int>(type: "int", nullable: true),
                    WednesdayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_Dishes_Fridays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "Fridays",
                        principalColumn: "FridayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MondayId = table.Column<int>(type: "int", nullable: true),
                    TuesdayId = table.Column<int>(type: "int", nullable: true),
                    WednesdayId = table.Column<int>(type: "int", nullable: true),
                    ThursdayId = table.Column<int>(type: "int", nullable: true),
                    FridayId = table.Column<int>(type: "int", nullable: true),
                    SaturdayId = table.Column<int>(type: "int", nullable: true),
                    SundayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Fridays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "Fridays",
                        principalColumn: "FridayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KindsOf",
                columns: table => new
                {
                    KindOfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KindOfName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindsOf", x => x.KindOfId);
                    table.ForeignKey(
                        name: "FK_KindsOf_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(7,2)", maxLength: 8, nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: true),
                    FridayId = table.Column<int>(type: "int", nullable: true),
                    MondayId = table.Column<int>(type: "int", nullable: true),
                    SaturdayId = table.Column<int>(type: "int", nullable: true),
                    SundayId = table.Column<int>(type: "int", nullable: true),
                    ThursdayId = table.Column<int>(type: "int", nullable: true),
                    TuesdayId = table.Column<int>(type: "int", nullable: true),
                    WednesdayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Fridays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "Fridays",
                        principalColumn: "FridayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Types_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProductId",
                table: "Groups",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_KindsOf_DishId",
                table: "KindsOf",
                column: "DishId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DishId",
                table: "Products",
                column: "DishId");

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
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WednesdayId",
                table: "Products",
                column: "WednesdayId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_DishId",
                table: "Types",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "KindsOf");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Fridays");

            migrationBuilder.DropTable(
                name: "Mondays");

            migrationBuilder.DropTable(
                name: "Saturdays");

            migrationBuilder.DropTable(
                name: "Sundays");

            migrationBuilder.DropTable(
                name: "Thursdays");

            migrationBuilder.DropTable(
                name: "Tuesdays");

            migrationBuilder.DropTable(
                name: "Wednesdays");
        }
    }
}
