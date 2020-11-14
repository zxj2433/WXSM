using Microsoft.EntityFrameworkCore.Migrations;

namespace WXSM.DataAccess.Migrations
{
    public partial class up202008051920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_on_shelf",
                table: "ShopItems",
                column: "on_shelf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopItems_on_shelf",
                table: "ShopItems");
        }
    }
}
