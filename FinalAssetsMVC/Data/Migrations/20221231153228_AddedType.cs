using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAssetsMVC.Data.Migrations
{
    public partial class AddedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile_Type",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile_Type",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Item");
        }
    }
}
