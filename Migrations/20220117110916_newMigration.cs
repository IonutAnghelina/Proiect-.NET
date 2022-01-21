using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_DAW.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Shops_ShopId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_ShopId",
                table: "Managers");

            migrationBuilder.RenameColumn(
                name: "noEmployees",
                table: "Shops",
                newName: "NoEmployees");

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShopId",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "NoEmployees",
                table: "Shops",
                newName: "noEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "ShopId",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ShopId",
                table: "Managers",
                column: "ShopId",
                unique: true,
                filter: "[ShopId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Shops_ShopId",
                table: "Managers",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
