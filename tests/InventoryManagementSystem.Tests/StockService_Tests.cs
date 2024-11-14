using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Moq;

namespace InventoryManagementSystem.Tests
{
    public class StockService_Tests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IStockRepository> _stockRepositoryMock;
        private readonly Mock<IWarehouseRepository> _warehouseRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly StockService _stockService;
        private readonly ProductService _productServiceMock;

        public StockService_Tests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _stockRepositoryMock = new Mock<IStockRepository>();
            _warehouseRepositoryMock = new Mock<IWarehouseRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _productServiceMock = new ProductService(
                _unitOfWorkMock.Object,
                _productRepositoryMock.Object,
                _categoryRepositoryMock.Object
            );
            _stockService = new StockService(
                _unitOfWorkMock.Object,
                _stockRepositoryMock.Object,
                _warehouseRepositoryMock.Object,
                _productServiceMock
            );
        }

        [Fact]
        public async Task GetAll_Stocks_By_ProductId_Should_Return_List()
        {
            var productId = 1;

            var mockProduct = new Product()
            {
                Id = 1,
                CategoryId = 2,
            };

            var mockCategory = new Category()
            {
                Id = 2,
            };

            var mockWarehouse1 = new Warehouse()
            {
                Id = 1,
                Name = "Warehouse 1",
                Location = "Location 1",
            };

            var mockWarehouse2 = new Warehouse()
            {
                Id = 2,
                Name = "Warehouse 2",
                Location = "Location 2",
            };

            var mockStocks = new List<Stock>()
            {
                new Stock() 
                {
                    Id = 1,
                    Warehouse = mockWarehouse1,
                    Product = mockProduct,
                    Quantity = 10,
                },
                new Stock()
                {
                    Id = 2,
                    Warehouse = mockWarehouse2,
                    Product = mockProduct,
                    Quantity = 10,
                },
            };

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockProduct);
            _categoryRepositoryMock.Setup(e => e.Get(mockProduct.CategoryId)).ReturnsAsync(mockCategory);
            _stockRepositoryMock.Setup(e => e.GetAllByProductId(It.IsAny<int>())).ReturnsAsync(mockStocks);

            var result = await _stockService.GetAllStocksOfProduct(productId);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var firstStock = result.First();
            Assert.Equal(10, firstStock.Quantity);

            var secondStock = result.Last();
            Assert.Equal(2, secondStock.Id);
        }

        [Fact]
        public async Task Get_Stocks_By_ProductId_Should_Return_Total_Quantity()
        {
            var productId = 1;

            var mockProduct = new Product()
            {
                Id = 1,
                CategoryId = 2,
            };

            var mockCategory = new Category()
            {
                Id = 2,
            };

            var mockWarehouse1 = new Warehouse()
            {
                Id = 1,
                Name = "Warehouse 1",
                Location = "Location 1",
            };

            var mockWarehouse2 = new Warehouse()
            {
                Id = 2,
                Name = "Warehouse 2",
                Location = "Location 2",
            };

            var mockStocks = new List<Stock>()
            {
                new Stock()
                {
                    Id = 1,
                    Warehouse = mockWarehouse1,
                    Product = mockProduct,
                    Quantity = 10,
                },
                new Stock()
                {
                    Id = 2,
                    Warehouse = mockWarehouse2,
                    Product = mockProduct,
                    Quantity = 10,
                },
            };

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockProduct);
            _categoryRepositoryMock.Setup(e => e.Get(mockProduct.CategoryId)).ReturnsAsync(mockCategory);
            _stockRepositoryMock.Setup(e => e.GetAllByProductId(It.IsAny<int>())).ReturnsAsync(mockStocks);

            var result = await _stockService.GetStockAmountByProductId(productId);

            Assert.NotNull(result);
            Assert.Equal(20, result.Quantity);
        }
    }
}
