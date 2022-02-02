using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class RequestDataModel
    {
        public int Id { get; set; }
       // public int categoryId { get; set; }
       // public int serviceId { get; set; }
        public string name { get; set; }
        public string categoryName { get; set; }
        public string serviceName { get; set; }

        public string modeOfPay { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}
