using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SP_GetServiceRequests]
                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select R.Id,R.categoryid,R.serviceid, U.name, C.categoryName,S.serviceName from Requests R inner join Categories C ON C.id=R.categoryid
inner join services S on S.id=R.serviceId
inner join users U ON U.id=R.userid
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
