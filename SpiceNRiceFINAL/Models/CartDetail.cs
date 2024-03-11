using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiceNRice.Models
{
    [Table("CartDetail")]
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int FoodItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price {  get; set; }
        public FoodItem FoodItem { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

    }
}
