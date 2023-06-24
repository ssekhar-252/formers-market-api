using FormersMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormersMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutSystemController : ControllerBase
    {
        private readonly ICheckoutSystemService _checkoutSystemService;

        public CheckoutSystemController(ICheckoutSystemService checkoutSystemService)
        {
            _checkoutSystemService = checkoutSystemService;
        }

        [HttpGet("products")]
        public Dictionary<string, Product> GetAllProducts()
        {
            return _checkoutSystemService.GetAllProducts();
        }

        [HttpGet("scan-item/{productCode}")]
        public Dictionary<string, int> Scan(string productCode)
        {
            return _checkoutSystemService.Scan(productCode);
        }

        [HttpGet("print-particulars")]
        public List<PrintParticulars> GetPrintParticulars()
        {
            return _checkoutSystemService.PrintBasket();
        }

        [HttpGet("clear-basket")]
        public void Clear()
        {
            _checkoutSystemService.ClearBasket();
        }
    }
}