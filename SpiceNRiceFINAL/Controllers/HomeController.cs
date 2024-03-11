
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpiceNRice.Models;
using SpiceNRice.Models.DTOs;
using System.Diagnostics;

namespace SpiceNRice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AboutUs()
		{
			return View();
		}
        public IActionResult ContactUs() 
        {
            return View();
        }
        public async Task<IActionResult> Menu(string sterm = "", int categoryId = 0)
        {
            IEnumerable<FoodItem> fooditems = await _homeRepository.GetFoodItems(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            FoodItemDisplayModel fooditemModel = new FoodItemDisplayModel
            {
                FoodItems = fooditems,
                Categories = categories,
                STerm = sterm,
                CategoryId = categoryId
            };
            return View(fooditemModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}