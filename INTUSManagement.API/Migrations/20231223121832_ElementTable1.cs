using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTUSManagement.API.Migrations
{
    public partial class ElementTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Element",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Element",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Width",
                table: "Element",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Element");
        }
    }
}
