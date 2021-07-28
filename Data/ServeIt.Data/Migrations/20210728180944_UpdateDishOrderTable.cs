using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateDishOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "DishOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "DishOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "DishOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DishOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_UserId",
                table: "DishOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_AspNetUsers_UserId",
                table: "DishOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_AspNetUsers_UserId",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_DishOrders_UserId",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DishOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DishOrders");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "DishOrders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
