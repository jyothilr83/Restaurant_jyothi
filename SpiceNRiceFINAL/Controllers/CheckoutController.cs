using Microsoft.AspNetCore.Mvc;
using SpiceNRice.Client;


namespace SpiceNRice.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly PaypalClient _paypalClient;
		private readonly ICartRepository _cartRepo;
		private readonly ShoppingCart _shoppingCart;

		public CheckoutController(PaypalClient paypalClient,ICartRepository cartRepo,ShoppingCart shoppingCart)
		{
			this._paypalClient = paypalClient;
			this._cartRepo = cartRepo;
			this._shoppingCart = shoppingCart;
		}

		public IActionResult Index()
		{
			// ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
			ViewBag.ClientId = _paypalClient.ClientId;

			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                // set the transaction price and currency
                var price = "100.00";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderId);

                var reference = response.purchase_units[0].reference_id;

                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
