using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class CreateRequestModel
    {
       [Key]
        public int Id { get; set; }
        [Required]
       
        public int userId { get; set; }
        [Required]
        public int categoryId { get; set; }
        [Required]
        public int serviceId { get; set; }
        [Required]
        public int modeOfPay { get; set; }
        [Required]
        public string startDate { get; set; }
       [Required]
        public string endDate { get; set; }

    }
}
