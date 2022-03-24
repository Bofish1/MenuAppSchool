using System.ComponentModel.DataAnnotations;
namespace Menu.Models
{
    public class Food
    {
        //EF core will generate this value
        public int FoodId { get; set; }

        [Required(ErrorMessage = "Please Enter a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter a Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter a Price.")]
        [Range(0,1000, ErrorMessage = "Price must be between 0 and 1000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a category.")]
        public string CategoryId { get; set; }
        public Category category { get; set; }
    }
}
