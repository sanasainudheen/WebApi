using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Test_WebApi.Data
{
    public class Order
    {
        [Key]
        public  int ReqId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PayMode { get; set; }

        public int Status { get; set; }
        // [Required]
        //  public string MainDocument { get; set; }
        //public  Datetime CreatedDate { get; set; }
       // System.DateTime CreatedDate = new System.DateTime();

        public string MainDocFileName { get; set; }
    }
}
