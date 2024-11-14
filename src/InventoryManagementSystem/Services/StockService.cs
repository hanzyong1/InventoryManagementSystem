using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Dtos.StockDto;
using InventoryManagementSystem.Dtos.WarehouseDto;

namespace InventoryManagementSystem.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockRepository _stockRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductService _productService;

        public StockService(
            IUnitOfWork unitOfWork,
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
        }

        public async Task<GetStockAmountDto> GetStockAmountByProductId(int productId)
        {
            var product = await _productService.Get(productId);

            var stocksOfProduct = await _stockRepository.GetAllByProductId(productId);

            var totalAmount = stocksOfProduct.Select(e => e.Quantity).Sum();

            return new GetStockAmountDto()
            {
                Product = product,
                Quantity = totalAmount,
            };
        }
    }
}
