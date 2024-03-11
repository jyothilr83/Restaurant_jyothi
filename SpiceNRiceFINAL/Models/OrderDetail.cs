using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpiceNRice.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        // orderdetails has a relationship with OrderID, FoodItemID 
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int FoodItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Price { get; set; }
        //this is the relationship FoodItemID and OrderID are FK
        public Order Order { get; set; }
        public FoodItem FoodItem { get; set; }

        internal static object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
