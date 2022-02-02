using System.ComponentModel.DataAnnotations;
namespace Test_WebApi.Models
{
    public class UserModel
    {
       
        public int Id { get; set; }
       
        public string name { get; set; }
       
        public string emailId { get; set; }
       
        public string userName { get; set; }
       
        public string password { get; set; }
    }
}
