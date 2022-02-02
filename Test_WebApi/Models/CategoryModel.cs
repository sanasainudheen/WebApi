using System.ComponentModel.DataAnnotations;

namespace Test_WebApi.Models
{
    public class CategoryModel
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public string categoryName { get; set; }
    }
}
