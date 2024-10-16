using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Dtos.ProductDto;
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

        [Fact]
        public async Task GetAll_Product_Should_Return_List()
        {
            var mockProducts = new List<Product>()
            {
                new Product { Id = 1, Name = "Product1", Description = "Description1", CategoryId = 1, Quantity = 10, Price = 100 },
                new Product { Id = 2, Name = "Product2", Description = "Description2", CategoryId = 2, Quantity = 5, Price = 200 },
            };

            var mockCategories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Category1", },
                new Category() { Id = 2, Name = "Category2", },
            };

            _productRepositoryMock.Setup(e => e.GetAll().Result).Returns(mockProducts);
            _categoryRepositoryMock.Setup(e => e.GetAll().Result).Returns(mockCategories);

            var result = await _productService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var firstProduct = result.First();
            Assert.Equal("Category1", firstProduct.Category.Name);

            var secondProduct = result.Last();
            Assert.Equal(2, secondProduct.Id);
        } 
    }
} 