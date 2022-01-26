namespace Test_WebApi.Data
{
    public class CreateRequest
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
        public int serviceId { get; set; }
        public int modeOfPay { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

       
    }
}
