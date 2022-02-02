using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class ServiceModel
    {
     
        public int Id { get; set; }

      
        public string serviceName { get; set; }
       
        public int categoryId { get; set; }
    }
}
