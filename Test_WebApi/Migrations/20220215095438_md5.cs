using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_WebApi.Migrations
{
    public partial class md5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[SP_GetServicesByReqId]
                     (
			   @OrderRequestId int
			   )
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select OrdDet.ReqDetId,OrdDet.ReqId,OrdDet.CategoryId,OrdDet.ServiceId,OrdDet.StartDate,
					OrdDet.EndDate,OrdDet.DocumentFileName,C.categoryName,S.serviceName
					from OrderDetails OrdDet inner join Orders O on O.ReqId=OrdDet.ReqId
					inner join Categories C On C.Id=OrdDet.CategoryId
					inner join Services S on S.Id=OrdDet.ServiceId
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
