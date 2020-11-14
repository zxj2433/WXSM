using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WXSM.DataAccess.Migrations
{
    public partial class up202008081143 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pricingStrategies",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    StrategyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pricingStrategies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "pricingStrategyLins",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    PSID = table.Column<Guid>(nullable: false),
                    MinCost = table.Column<int>(nullable: false),
                    MaxCost = table.Column<int>(nullable: false),
                    ShopCommission = table.Column<double>(nullable: false),
                    CT = table.Column<int>(nullable: false),
                    OwnCommission = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pricingStrategyLins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_pricingStrategyLins_pricingStrategies_PSID",
                        column: x => x.PSID,
                        principalTable: "pricingStrategies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pricingStrategyLins_PSID",
                table: "pricingStrategyLins",
                column: "PSID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pricingStrategyLins");

            migrationBuilder.DropTable(
                name: "pricingStrategies");
        }
    }
}
