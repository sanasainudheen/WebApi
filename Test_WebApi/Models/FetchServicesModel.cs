using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class FetchServicesModel
    {
        [Key]
    public int ReqDetId { get; set; }
    public int ReqId { get; set; }

    public int CategoryId { get; set; }

    public int ServiceId { get; set; }

    public string StartDate { get; set; }

    public string EndDate { get; set; }

    public string DocumentFileName { get; set; }

    public string CategoryName { get; set; }
    public string ServiceName { get; set; }

    }
}
