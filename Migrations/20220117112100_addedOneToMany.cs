using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_DAW.Migrations
{
    public partial class addedOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopId",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShopId",
                table: "Employees",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Shops_ShopId",
                table: "Employees",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Shops_ShopId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ShopId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Employees");
        }
    }
}
