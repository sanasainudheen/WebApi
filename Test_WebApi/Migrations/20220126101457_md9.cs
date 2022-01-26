using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMode",
                table: "RequestData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "RequestData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "endDate",
                table: "RequestData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "serviceId",
                table: "RequestData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "startDate",
                table: "RequestData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "serviceId",
                table: "RequestData");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "RequestData");
        }
    }
}
