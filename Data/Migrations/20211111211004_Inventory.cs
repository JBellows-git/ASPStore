using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupProject.Data.Migrations
{
    public partial class Inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryNumber = table.Column<int>(nullable: false),
                    InventoryName = table.Column<string>(nullable: true),
                    InventoryDescription = table.Column<string>(nullable: true),
                    InventoryStock = table.Column<int>(nullable: false),
                    InventoryPrice = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
