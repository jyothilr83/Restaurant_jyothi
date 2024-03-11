using Microsoft.EntityFrameworkCore;

namespace SpiceNRice.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<FoodItem>> GetFoodItems(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<FoodItem> fooditems = await (from fooditem in _db.FoodItems
                                             join category in _db.Categories
                                             on fooditem.CategoryId equals category.Id
                                             where string.IsNullOrWhiteSpace(sTerm) || (fooditem != null && fooditem.FoodItemName.ToLower().StartsWith(sTerm))
                                             select new FoodItem
                                             {
                                                 Id = fooditem.Id,
                                                 Image = fooditem.Image,
                                                 Description = fooditem.Description,
                                                 FoodItemName = fooditem.FoodItemName,
                                                 CategoryId = fooditem.CategoryId,
                                                 Price = fooditem.Price,
                                                 CategoryName = category.CategoryName
                                             }
                         ).ToListAsync();
            if (categoryId > 0)
            {

                fooditems = fooditems.Where(a => a.CategoryId == categoryId).ToList();
            }
            return fooditems;

        }
    }
}
