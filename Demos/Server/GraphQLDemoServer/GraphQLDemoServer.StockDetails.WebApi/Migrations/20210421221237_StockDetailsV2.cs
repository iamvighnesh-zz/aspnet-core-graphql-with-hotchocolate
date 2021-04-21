using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQLDemoServer.StockDetails.WebApi.Migrations
{
    public partial class StockDetailsV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalProductId",
                table: "Products");
        }
    }
}
