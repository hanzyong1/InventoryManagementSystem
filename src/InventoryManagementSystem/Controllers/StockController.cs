using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;

        public StockController(
            IStockService stockService,
            IProductService productService
            )
        {
            _stockService = stockService;
            _productService = productService;
        }

        [HttpGet("GetAllStocksOfProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllStocksOfProduct(int id)
        {
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            var stocks = await _stockService.GetAllStocksOfProduct(id);

            return Ok(stocks);
        }
    }
}
