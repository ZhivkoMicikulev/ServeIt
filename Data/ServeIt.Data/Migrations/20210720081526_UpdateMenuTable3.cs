using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServeIt.Data.Migrations
{
    public partial class UpdateMenuTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenusDishes_Dishes_DishId",
                table: "MenusDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_MenusDishes_Menus_MenuId",
                table: "MenusDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantsMenus_Menus_MenuId",
                table: "RestaurantsMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantsMenus_Restaurants_RestaurantId",
                table: "RestaurantsMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantsMenus",
                table: "RestaurantsMenus");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantsMenus_IsDeleted",
                table: "RestaurantsMenus");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantsMenus_MenuId",
                table: "RestaurantsMenus");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantsMenus_RestaurantId",
                table: "RestaurantsMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenusDishes",
                table: "MenusDishes");

            migrationBuilder.DropIndex(
                name: "IX_MenusDishes_IsDeleted",
                table: "MenusDishes");

            migrationBuilder.DropIndex(
                name: "IX_MenusDishes_MenuId",
                table: "MenusDishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RestaurantsMenus");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "RestaurantsMenus");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "RestaurantsMenus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantsMenus");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "RestaurantsMenus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenusDishes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenusDishes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MenusDishes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenusDishes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MenusDishes");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "RestaurantsMenus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuId",
                table: "RestaurantsMenus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuId",
                table: "MenusDishes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishId",
                table: "MenusDishes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantsMenus",
                table: "RestaurantsMenus",
                columns: new[] { "RestaurantId", "MenuId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenusDishes",
                table: "MenusDishes",
                columns: new[] { "MenuId", "DishId" });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsMenus_MenuId",
                table: "RestaurantsMenus",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenusDishes_Dishes_DishId",
                table: "MenusDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenusDishes_Menus_MenuId",
                table: "MenusDishes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantsMenus_Menus_MenuId",
                table: "RestaurantsMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantsMenus_Restaurants_RestaurantId",
                table: "RestaurantsMenus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenusDishes_Dishes_DishId",
                table: "MenusDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_MenusDishes_Menus_MenuId",
                table: "MenusDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantsMenus_Menus_MenuId",
                table: "RestaurantsMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantsMenus_Restaurants_RestaurantId",
                table: "RestaurantsMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantsMenus",
                table: "RestaurantsMenus");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantsMenus_MenuId",
                table: "RestaurantsMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenusDishes",
                table: "MenusDishes");

            migrationBuilder.AlterColumn<string>(
                name: "MenuId",
                table: "RestaurantsMenus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "RestaurantsMenus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "RestaurantsMenus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "RestaurantsMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "RestaurantsMenus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantsMenus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "RestaurantsMenus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DishId",
                table: "MenusDishes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MenuId",
                table: "MenusDishes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MenusDishes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenusDishes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MenusDishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenusDishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MenusDishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantsMenus",
                table: "RestaurantsMenus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenusDishes",
                table: "MenusDishes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsMenus_IsDeleted",
                table: "RestaurantsMenus",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsMenus_MenuId",
                table: "RestaurantsMenus",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsMenus_RestaurantId",
                table: "RestaurantsMenus",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenusDishes_IsDeleted",
                table: "MenusDishes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MenusDishes_MenuId",
                table: "MenusDishes",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenusDishes_Dishes_DishId",
                table: "MenusDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenusDishes_Menus_MenuId",
                table: "MenusDishes",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantsMenus_Menus_MenuId",
                table: "RestaurantsMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantsMenus_Restaurants_RestaurantId",
                table: "RestaurantsMenus",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
