//Adding data annotations for validation purposes
using System.ComponentModel.DataAnnotations;

namespace Day27_MvcDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        //Name is a required field with a maximum length of 100 characters
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        //Price is a decimal type to handle currency values accurately
        //Adding a range validation to ensure the price is positive
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal Price { get; set; }
    }
}
