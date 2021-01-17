using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.DataAccess.Migrations
{
    public partial class AddBiddersAndItemBids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bidders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemBids",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderId = table.Column<long>(nullable: false),
                    ItemId = table.Column<long>(nullable: false),
                    Bid = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBids_Bidders_BidderId",
                        column: x => x.BidderId,
                        principalTable: "Bidders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemBids_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemBids_BidderId",
                table: "ItemBids",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBids_ItemId",
                table: "ItemBids",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBids");

            migrationBuilder.DropTable(
                name: "Bidders");
        }
    }
}
