using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace Test_WebApi.Models
{
    public class OrderModel
    {
        [Key]
        public int ReqId { get; set; }
        public int UserId { get; set; }
        public int PayMode { get; set; }
        [NotMapped]
        public IFormFile MainDocument { get; set; }
    }
}
