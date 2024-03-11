using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SpiceNRice.Models
{
    [Table("Category")]
    public class Category
    {//Genre has a relationship with book class/database
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }
        public List<FoodItem> FoodItems { get; set; }

    }
}
    

