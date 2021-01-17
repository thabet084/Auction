using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.DataAccess.Migrations
{
    public partial class ReAddExceptionLogEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(maxLength: 200, nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Exception = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionLogs");
        }
    }
}
