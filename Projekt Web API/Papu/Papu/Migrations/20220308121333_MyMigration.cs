using Microsoft.EntityFrameworkCore.Migrations;

namespace Papu.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    BreakfastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.BreakfastId);
                });

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
                name: "Dinners",
                columns: table => new
                {
                    DinnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinners", x => x.DinnerId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DishDescription = table.Column<string>(type: "nvarchar(1300)", maxLength: 1300, nullable: false),
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
                name: "Lunches",
                columns: table => new
                {
                    LunchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunches", x => x.LunchId);
                });

            migrationBuilder.CreateTable(
                name: "SecondBreakfasts",
                columns: table => new
                {
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondBreakfasts", x => x.SecondBreakfastId);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.SnackId);
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
                name: "DinnerDishes",
                columns: table => new
                {
                    DinnerId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerDishes", x => new { x.DinnerId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DinnerDishes_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DinnerDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishBreakfasts",
                columns: table => new
                {
                    BreakfastId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishBreakfasts", x => new { x.BreakfastId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishBreakfasts_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishBreakfasts_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "LunchDishes",
                columns: table => new
                {
                    LunchId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchDishes", x => new { x.LunchId, x.DishId });
                    table.ForeignKey(
                        name: "FK_LunchDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchDishes_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishSecondBreakfasts",
                columns: table => new
                {
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishSecondBreakfasts", x => new { x.SecondBreakfastId, x.DishId });
                    table.ForeignKey(
                        name: "FK_DishSecondBreakfasts_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishSecondBreakfasts_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridays",
                columns: table => new
                {
                    FridayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridays", x => x.FridayId);
                    table.ForeignKey(
                        name: "FK_Fridays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fridays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fridays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fridays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fridays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Mondays",
                columns: table => new
                {
                    MondayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mondays", x => x.MondayId);
                    table.ForeignKey(
                        name: "FK_Mondays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Mondays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Mondays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Mondays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Mondays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Saturdays",
                columns: table => new
                {
                    SaturdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saturdays", x => x.SaturdayId);
                    table.ForeignKey(
                        name: "FK_Saturdays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saturdays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saturdays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saturdays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Saturdays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SnackDishes",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackDishes", x => new { x.SnackId, x.DishId });
                    table.ForeignKey(
                        name: "FK_SnackDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SnackDishes_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sundays",
                columns: table => new
                {
                    SundayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sundays", x => x.SundayId);
                    table.ForeignKey(
                        name: "FK_Sundays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sundays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sundays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sundays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sundays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Thursdays",
                columns: table => new
                {
                    ThursdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thursdays", x => x.ThursdayId);
                    table.ForeignKey(
                        name: "FK_Thursdays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Thursdays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Thursdays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Thursdays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Thursdays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tuesdays",
                columns: table => new
                {
                    TuesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuesdays", x => x.TuesdayId);
                    table.ForeignKey(
                        name: "FK_Tuesdays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tuesdays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tuesdays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tuesdays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tuesdays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Wednesdays",
                columns: table => new
                {
                    WednesdayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wednesdays", x => x.WednesdayId);
                    table.ForeignKey(
                        name: "FK_Wednesdays_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Wednesdays_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Wednesdays_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Wednesdays_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Wednesdays_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Mondays_MondayId",
                        column: x => x.MondayId,
                        principalTable: "Mondays",
                        principalColumn: "MondayId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Saturdays_SaturdayId",
                        column: x => x.SaturdayId,
                        principalTable: "Saturdays",
                        principalColumn: "SaturdayId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Sundays_SundayId",
                        column: x => x.SundayId,
                        principalTable: "Sundays",
                        principalColumn: "SundayId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Thursdays_ThursdayId",
                        column: x => x.ThursdayId,
                        principalTable: "Thursdays",
                        principalColumn: "ThursdayId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Tuesdays_TuesdayId",
                        column: x => x.TuesdayId,
                        principalTable: "Tuesdays",
                        principalColumn: "TuesdayId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Menus_Wednesdays_WednesdayId",
                        column: x => x.WednesdayId,
                        principalTable: "Wednesdays",
                        principalColumn: "WednesdayId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DinnerProducts",
                columns: table => new
                {
                    DinnerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerProducts", x => new { x.DinnerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DinnerProducts_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "DinnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DinnerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
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
                name: "LunchProducts",
                columns: table => new
                {
                    LunchId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchProducts", x => new { x.LunchId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_LunchProducts_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "LunchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LunchProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBreakfasts",
                columns: table => new
                {
                    BreakfastId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBreakfasts", x => new { x.BreakfastId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductBreakfasts_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "BreakfastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBreakfasts_Products_ProductId",
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
                name: "ProductSecondBreakfasts",
                columns: table => new
                {
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSecondBreakfasts", x => new { x.SecondBreakfastId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductSecondBreakfasts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSecondBreakfasts_SecondBreakfasts_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfasts",
                        principalColumn: "SecondBreakfastId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnackProducts",
                columns: table => new
                {
                    SnackId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackProducts", x => new { x.SnackId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SnackProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SnackProducts_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DinnerDishes_DishId",
                table: "DinnerDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerProducts_ProductId",
                table: "DinnerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DishBreakfasts_DishId",
                table: "DishBreakfasts",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishKindsOf_KindOfId",
                table: "DishKindsOf",
                column: "KindOfId");

            migrationBuilder.CreateIndex(
                name: "IX_DishProducts_DishId",
                table: "DishProducts",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishSecondBreakfasts_DishId",
                table: "DishSecondBreakfasts",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTypes_TypeId",
                table: "DishTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_BreakfastId",
                table: "Fridays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_DinnerId",
                table: "Fridays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_LunchId",
                table: "Fridays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_SecondBreakfastId",
                table: "Fridays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fridays_SnackId",
                table: "Fridays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LunchDishes_DishId",
                table: "LunchDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_LunchProducts_ProductId",
                table: "LunchProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_FridayId",
                table: "Menus",
                column: "FridayId",
                unique: true,
                filter: "[FridayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MondayId",
                table: "Menus",
                column: "MondayId",
                unique: true,
                filter: "[MondayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SaturdayId",
                table: "Menus",
                column: "SaturdayId",
                unique: true,
                filter: "[SaturdayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_SundayId",
                table: "Menus",
                column: "SundayId",
                unique: true,
                filter: "[SundayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ThursdayId",
                table: "Menus",
                column: "ThursdayId",
                unique: true,
                filter: "[ThursdayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TuesdayId",
                table: "Menus",
                column: "TuesdayId",
                unique: true,
                filter: "[TuesdayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_WednesdayId",
                table: "Menus",
                column: "WednesdayId",
                unique: true,
                filter: "[WednesdayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_BreakfastId",
                table: "Mondays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_DinnerId",
                table: "Mondays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_LunchId",
                table: "Mondays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_SecondBreakfastId",
                table: "Mondays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mondays_SnackId",
                table: "Mondays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBreakfasts_ProductId",
                table: "ProductBreakfasts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_GroupId",
                table: "ProductGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSecondBreakfasts_ProductId",
                table: "ProductSecondBreakfasts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_BreakfastId",
                table: "Saturdays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_DinnerId",
                table: "Saturdays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_LunchId",
                table: "Saturdays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_SecondBreakfastId",
                table: "Saturdays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Saturdays_SnackId",
                table: "Saturdays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SnackDishes_DishId",
                table: "SnackDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackProducts_ProductId",
                table: "SnackProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_BreakfastId",
                table: "Sundays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_DinnerId",
                table: "Sundays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_LunchId",
                table: "Sundays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_SecondBreakfastId",
                table: "Sundays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sundays_SnackId",
                table: "Sundays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_BreakfastId",
                table: "Thursdays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_DinnerId",
                table: "Thursdays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_LunchId",
                table: "Thursdays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_SecondBreakfastId",
                table: "Thursdays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thursdays_SnackId",
                table: "Thursdays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_BreakfastId",
                table: "Tuesdays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_DinnerId",
                table: "Tuesdays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_LunchId",
                table: "Tuesdays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_SecondBreakfastId",
                table: "Tuesdays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tuesdays_SnackId",
                table: "Tuesdays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_BreakfastId",
                table: "Wednesdays",
                column: "BreakfastId",
                unique: true,
                filter: "[BreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_DinnerId",
                table: "Wednesdays",
                column: "DinnerId",
                unique: true,
                filter: "[DinnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_LunchId",
                table: "Wednesdays",
                column: "LunchId",
                unique: true,
                filter: "[LunchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_SecondBreakfastId",
                table: "Wednesdays",
                column: "SecondBreakfastId",
                unique: true,
                filter: "[SecondBreakfastId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wednesdays_SnackId",
                table: "Wednesdays",
                column: "SnackId",
                unique: true,
                filter: "[SnackId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DinnerDishes");

            migrationBuilder.DropTable(
                name: "DinnerProducts");

            migrationBuilder.DropTable(
                name: "DishBreakfasts");

            migrationBuilder.DropTable(
                name: "DishKindsOf");

            migrationBuilder.DropTable(
                name: "DishProducts");

            migrationBuilder.DropTable(
                name: "DishSecondBreakfasts");

            migrationBuilder.DropTable(
                name: "DishTypes");

            migrationBuilder.DropTable(
                name: "LunchDishes");

            migrationBuilder.DropTable(
                name: "LunchProducts");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "ProductBreakfasts");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductSecondBreakfasts");

            migrationBuilder.DropTable(
                name: "SnackDishes");

            migrationBuilder.DropTable(
                name: "SnackProducts");

            migrationBuilder.DropTable(
                name: "KindsOf");

            migrationBuilder.DropTable(
                name: "Types");

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

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "Dinners");

            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropTable(
                name: "SecondBreakfasts");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
