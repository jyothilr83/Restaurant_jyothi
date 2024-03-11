using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SpiceNRice.Models
{
    [Table("FoodItem")]
    public class FoodItem
    {//this is the main/base/parent class 
     //has a relationships with many tables 
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FoodItemName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }
}
