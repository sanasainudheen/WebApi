using System.Collections.Generic;

namespace Test_WebApi.Models
{
    public class OrderItemDetailsViewModel
    {

        public  OrderModel order { get; set; }
        public List<OrderDetailModel> itemDetails { get; set; }

       
    }
}
