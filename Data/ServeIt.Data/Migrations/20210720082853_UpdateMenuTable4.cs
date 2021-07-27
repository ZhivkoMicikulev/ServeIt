using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateMenuTable4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenusDishes");

            migrationBuilder.DropTable(
                name: "RestaurantsMenus");

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "Restaurants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurants",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menus_MenuId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Restaurants");

            migrationBuilder.CreateTable(
                name: "MenusDishes",
                columns: table => new
                {
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DishId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenusDishes", x => new { x.MenuId, x.DishId });
                    table.ForeignKey(
                        name: "FK_MenusDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenusDishes_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantsMenus",
                columns: table => new
                {
                    RestaurantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenuId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantsMenus", x => new { x.RestaurantId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_RestaurantsMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantsMenus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenusDishes_DishId",
                table: "MenusDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsMenus_MenuId",
                table: "RestaurantsMenus",
                column: "MenuId");
        }
    }
}
