using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class FetchOrdersModel
    {
        [Key]
        public int ReqId { get; set; }
        public int PayMode { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        // public int categoryId { get; set; }
        // public int serviceId { get; set; }
        public string name { get; set; }
        public string PaymentMode { get; set; }
        public string OrderStatus { get; set; }
        public string MainDocFileName { get; set; }

    }
}
