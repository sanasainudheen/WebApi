using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Test_WebApi.Models
{
    public class NewOrderModel
    {
        public int ReqId { get; set; }
        public int UserId { get; set; }
        public int PayMode { get; set; }
        public int Status { get; set; }

        public string MainDocFileName { get; set; }
       // public IFormFile MainDocument { get; set; }
        public List<OrderDetailModel> Items { get; set; }
    }
}
