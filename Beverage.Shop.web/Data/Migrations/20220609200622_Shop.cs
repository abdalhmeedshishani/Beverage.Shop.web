using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beverage.Shop.web.Data.Migrations
{
    public partial class Shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfDrink = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FruitsAndSpices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    I = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    II = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    III = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    V = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VII = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIII = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitsAndSpices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FruitsAndSpices_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FruitsAndSpices_DrinkId",
                table: "FruitsAndSpices",
                column: "DrinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FruitsAndSpices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Drinks");
        }
    }
}
