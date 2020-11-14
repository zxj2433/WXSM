using Microsoft.EntityFrameworkCore.Migrations;

namespace WXSM.DataAccess.Migrations
{
    public partial class up202008051910 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_title",
                table: "ShopItems",
                column: "title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopItems_title",
                table: "ShopItems");
        }
    }
}
