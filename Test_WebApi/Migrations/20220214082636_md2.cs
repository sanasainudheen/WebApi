using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SP_GetServiceRequests]
                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select O.ReqId,O.PayMode,O.Status,O.UserId, U.name,
					case O.PayMode when 1 then 'Debit Card' else 'Credit Card' end as PaymentMode,
					case O.Status when 1 then 'Pending' when 2 then 'Completed' when 3 then 'Cancelled'end as OrderStatus,
					O.MainDocFileName
					from Orders O inner join users U ON U.id=O.userid
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
