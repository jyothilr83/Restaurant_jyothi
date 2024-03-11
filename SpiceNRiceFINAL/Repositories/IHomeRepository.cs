namespace SpiceNRice.Repositories;

public interface IHomeRepository
{
    Task<IEnumerable<FoodItem>> GetFoodItems(string sTerm = "", int categoryId = 0);
    Task<IEnumerable<Category>> Categories();
}