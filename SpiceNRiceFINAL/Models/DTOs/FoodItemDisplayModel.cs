

namespace SpiceNRice.Models.DTOs
{
    public class FoodItemDisplayModel
    {
            public IEnumerable<FoodItem> FoodItems { get; set; }
            public IEnumerable<Category> Categories { get; set; }
            public string STerm { get; set; } = "";
            public int CategoryId { get; set; } = 0;
        }
    }

