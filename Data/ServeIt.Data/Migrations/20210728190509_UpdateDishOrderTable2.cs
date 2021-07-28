using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateDishOrderTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "DishOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "DishOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_RestaurantId",
                table: "DishOrders",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Restaurants_RestaurantId",
                table: "DishOrders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Restaurants_RestaurantId",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishOrders_RestaurantId",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "DishOrders");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "DishOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
