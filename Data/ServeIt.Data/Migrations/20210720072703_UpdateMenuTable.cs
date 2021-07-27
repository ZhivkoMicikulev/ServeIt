using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodStyles_Menus_MenuId",
                table: "FoodStyles");

            migrationBuilder.DropIndex(
                name: "IX_FoodStyles_MenuId",
                table: "FoodStyles");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "FoodStyles");

            migrationBuilder.CreateTable(
                name: "FoodStyleMenu",
                columns: table => new
                {
                    FoodStylesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStyleMenu", x => new { x.FoodStylesId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_FoodStyleMenu_FoodStyles_FoodStylesId",
                        column: x => x.FoodStylesId,
                        principalTable: "FoodStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodStyleMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodStyleMenu_MenusId",
                table: "FoodStyleMenu",
                column: "MenusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodStyleMenu");

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "FoodStyles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodStyles_MenuId",
                table: "FoodStyles",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodStyles_Menus_MenuId",
                table: "FoodStyles",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
