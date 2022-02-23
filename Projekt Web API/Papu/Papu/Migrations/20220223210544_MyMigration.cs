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
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                    DishImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.DishId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "KindsOf",
                columns: table => new
                {
                    KindOfId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KindOfName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindsOf", x => x.KindOfId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "DishKindsOf",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    KindOfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishKindsOf", x => new { x.DishId, x.KindOfId });
                    table.ForeignKey(
                        name: "FK_DishKindsOf_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishKindsOf_KindsOf_KindOfId",
                        column: x => x.KindOfId,
                        principalTable: "KindsOf",
                        principalColumn: "KindOfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridays",
                columns: table => new
                {
                    FridayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridays", x => x.FridayId);
                    table.ForeignKey(
                        name: "FK_Fridays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Mondays",
                columns: table => new
                {
                    MondayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mondays", x => x.MondayId);
                    table.ForeignKey(
                        name: "FK_Mondays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Saturdays",
                columns: table => new
                {
                    SaturdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturdays", x => x.SaturdayId);
                    table.ForeignKey(
                        name: "FK_Saturdays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sundays",
                columns: table => new
                {
                    SundayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sundays", x => x.SundayId);
                    table.ForeignKey(
                        name: "FK_Sundays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Thursdays",
                columns: table => new
                {
                    ThursdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thursdays", x => x.ThursdayId);
                    table.ForeignKey(
                        name: "FK_Thursdays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tuesdays",
                columns: table => new
                {
                    TuesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuesdays", x => x.TuesdayId);
                    table.ForeignKey(
                        name: "FK_Tuesdays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Wednesdays",
                columns: table => new
                {
                    WednesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuRef = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wednesdays", x => x.WednesdayId);
                    table.ForeignKey(
                        name: "FK_Wednesdays_Menus_MenuRef",
                        column: x => x.MenuRef,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DishTypes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTypes", x => new { x.DishId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_DishTypes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
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
                    ProductImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DishFridays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    FridayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishFridays", x => new { x.FridayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishFridays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishFridays_Fridays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "Fridays",
                        principalColumn: "FridayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishMondays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    MondayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMondays", x => new { x.MondayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishMondays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMondays_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishSaturdays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    SaturdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSaturdays", x => new { x.SaturdayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishSaturdays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishSaturdays_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishSundays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    SundayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSundays", x => new { x.SundayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishSundays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishSundays_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishThursdays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    ThursdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishThursdays", x => new { x.ThursdayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishThursdays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishThursdays_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishTuesdays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    TuesdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTuesdays", x => new { x.TuesdayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishTuesdays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishTuesdays_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishWednesdays",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    WednesdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishWednesdays", x => new { x.WednesdayId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishWednesdays_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishWednesdays_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishProducts", x => new { x.ProductId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishProducts_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFridays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FridayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFridays", x => new { x.FridayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductFridays_Fridays_FridayId",
                        column: x => x.FridayId,
                        principalTable: "Fridays",
                        principalColumn: "FridayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFridays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => new { x.ProductId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_ProductGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGroups_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMondays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MondayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMondays", x => new { x.MondayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductMondays_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMondays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSaturdays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SaturdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaturdays", x => new { x.SaturdayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductSaturdays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSaturdays_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSundays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SundayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSundays", x => new { x.SundayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductSundays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSundays_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductThursdays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ThursdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductThursdays", x => new { x.ThursdayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductThursdays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductThursdays_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTuesdays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TuesdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTuesdays", x => new { x.TuesdayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductTuesdays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTuesdays_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWednesdays",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WednesdayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWednesdays", x => new { x.WednesdayId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductWednesdays_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWednesdays_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishFridays_DishId",
                table: "DishFridays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishKindsOf_KindOfId",
                table: "DishKindsOf",
                column: "KindOfId");

            migrationBuilder.CreateIndex(
                name: "IX_DishMondays_DishId",
                table: "DishMondays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishProducts_DishId",
                table: "DishProducts",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishSaturdays_DishId",
                table: "DishSaturdays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishSundays_DishId",
                table: "DishSundays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishThursdays_DishId",
                table: "DishThursdays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTuesdays_DishId",
                table: "DishTuesdays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTypes_TypeId",
                table: "DishTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DishWednesdays_DishId",
                table: "DishWednesdays",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_MenuRef",
                table: "Fridays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_MenuRef",
                table: "Mondays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFridays_ProductId",
                table: "ProductFridays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_GroupId",
                table: "ProductGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMondays_ProductId",
                table: "ProductMondays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaturdays_ProductId",
                table: "ProductSaturdays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSundays_ProductId",
                table: "ProductSundays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductThursdays_ProductId",
                table: "ProductThursdays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTuesdays_ProductId",
                table: "ProductTuesdays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWednesdays_ProductId",
                table: "ProductWednesdays",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_MenuRef",
                table: "Saturdays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_MenuRef",
                table: "Sundays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_MenuRef",
                table: "Thursdays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_MenuRef",
                table: "Tuesdays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_MenuRef",
                table: "Wednesdays",
                column: "MenuRef",
                unique: true,
                filter: "[MenuRef] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishFridays");

            migrationBuilder.DropTable(
                name: "DishKindsOf");

            migrationBuilder.DropTable(
                name: "DishMondays");

            migrationBuilder.DropTable(
                name: "DishProducts");

            migrationBuilder.DropTable(
                name: "DishSaturdays");

            migrationBuilder.DropTable(
                name: "DishSundays");

            migrationBuilder.DropTable(
                name: "DishThursdays");

            migrationBuilder.DropTable(
                name: "DishTuesdays");

            migrationBuilder.DropTable(
                name: "DishTypes");

            migrationBuilder.DropTable(
                name: "DishWednesdays");

            migrationBuilder.DropTable(
                name: "ProductFridays");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductMondays");

            migrationBuilder.DropTable(
                name: "ProductSaturdays");

            migrationBuilder.DropTable(
                name: "ProductSundays");

            migrationBuilder.DropTable(
                name: "ProductThursdays");

            migrationBuilder.DropTable(
                name: "ProductTuesdays");

            migrationBuilder.DropTable(
                name: "ProductWednesdays");

            migrationBuilder.DropTable(
                name: "KindsOf");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Fridays");

            migrationBuilder.DropTable(
                name: "Groups");

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "Wednesdays");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
