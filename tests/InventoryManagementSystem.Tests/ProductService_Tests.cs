using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Moq;

namespace InventoryManagementSystem.Tests
{
    public class ProductService_Tests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly ProductService _productService;

        public ProductService_Tests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _productService = new ProductService(
                _productRepositoryMock.Object,
                _categoryRepositoryMock.Object
            );
        }

        [Fact]
        public async Task Get_Product_With_Invalid_Id_Should_Return_Null()
        {
            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>()).Result).Returns(() => null);

            var result = await _productService.Get(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task Get_Product_With_Valid_Id_Should_Return_ProductDto()
        {
            var mockProduct = new Product()
            {
                Id = 1,
                CategoryId = 2,
            };

            var mockCategory = new Category()
            {
                Id = 2,
            };

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>()).Result).Returns(mockProduct);
            _categoryRepositoryMock.Setup(e => e.Get(mockProduct.CategoryId).Result).Returns(mockCategory);

            var result = await _productService.Get(1);

            Assert.NotNull(result);
            Assert.Equal(mockProduct.Id, result.Id);
            Assert.Equal(mockCategory.Id, result.Category.Id);
        }
    }
}
