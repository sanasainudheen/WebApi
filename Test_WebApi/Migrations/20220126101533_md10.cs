using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[SP_GetServiceRequests]
                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                     select 
					R.Id,					
					 U.name, C.categoryName,S.serviceName,
					 case modeOfPay when 1 then 'Debit Card' when 2 then 'Credit Card' end AS PaymentMode,
					R.startDate,R.endDate
					  from CreateRequest R inner join Categories C ON C.id=R.categoryid
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
