using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProject.Data.Migrations
{
    public partial class removeInventoryNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Inventories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryNumber",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
