using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "ServicesData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "ServicesData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "ServicesData");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "ServicesData");
        }
    }
}
