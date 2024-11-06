using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Dtos.StockDto;
using InventoryManagementSystem.Dtos.WarehouseDto;

namespace InventoryManagementSystem.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductService _productService;

        public StockService(
            IStockRepository stockRepository,
            IWarehouseRepository warehouseRepository,
            IProductService productService
            )
        {
            _stockRepository = stockRepository;
            _warehouseRepository = warehouseRepository;
            _productService = productService;
        }

        public async Task<List<GetStockDto>> GetAllStocksOfProduct(int productId)
        {
            var product = await _productService.Get(productId);

            var stocksOfProduct = await _stockRepository.GetAllByProductId(productId);

            List<GetStockDto> warehouseDtoList = stocksOfProduct.Select(e => new GetStockDto()
            {
                Id = e.Id,
                Warehouse = new GetWarehouseDto()
                {
                    Id = e.Warehouse.Id,
                    Name = e.Warehouse.Name,
                    Location = e.Warehouse.Location,
                },
                Product = product,
                Quantity = e.Quantity,
            }).ToList();

            return warehouseDtoList;

            //var warehouseDtoList = new List<GetWarehouseDto>();
            //foreach (var stock in stocksOfProduct)
            //{
            //    var warehouse = warehouseList.FirstOrDefault(e => e.Id == stock.WarehouseId);

            //    warehouseDtoList.Add(warehouse);
            //}
        }
    }
}
