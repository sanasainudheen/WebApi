using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace Test_WebApi.Data
{
    public class OrderDetails
    {
        [Key]
        public int ReqDetId { get; set; }
        [Required]
        public int ReqId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
       
        
        public string DocumentFileName { get; set; }

    }
}
