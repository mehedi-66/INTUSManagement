using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTUSManagement.API.Migrations
{
    public partial class TestChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId1",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_OrderId1",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "Windows");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Windows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Windows_Orders_OrderId",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_OrderId",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Windows");

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "Windows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId1",
                table: "Windows",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_Orders_OrderId1",
                table: "Windows",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
