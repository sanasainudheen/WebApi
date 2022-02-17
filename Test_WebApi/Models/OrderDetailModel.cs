using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_WebApi.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int ReqDetId { get; set; }
        public int ReqId { get; set; }

        public int CategoryId { get; set; }

        public int ServiceId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string DocFileName { get; set; }
        //  [NotMapped]
        //   public IFormFile Document { get; set; }
    }
}
