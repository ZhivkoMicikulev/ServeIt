using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateOrderTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlaceToGet",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Orders",
                newName: "restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                newName: "IX_Orders_restaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "restaurantId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_restaurantId",
                table: "Orders",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurantId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Orders",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_restaurantId",
                table: "Orders",
                newName: "IX_Orders_RestaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PlaceToGet",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
