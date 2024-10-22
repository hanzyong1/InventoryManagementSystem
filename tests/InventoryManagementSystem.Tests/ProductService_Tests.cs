using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Moq;

namespace InventoryManagementSystem.Tests
{
    public class ProductService_Tests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly ProductService _productService;

        public ProductService_Tests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _productService = new ProductService(
                _unitOfWorkMock.Object,
                _productRepositoryMock.Object,
                _categoryRepositoryMock.Object
            );
        }

        [Fact]
        public async Task Get_Product_With_Invalid_Id_Should_Return_Null()
        {
            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(() => null);

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

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockProduct);
            _categoryRepositoryMock.Setup(e => e.Get(mockProduct.CategoryId)).ReturnsAsync(mockCategory);

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
                new Product { Id = 1, CategoryId = 1, },
                new Product { Id = 2, CategoryId = 2, },
            };

            var mockCategories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Category1", },
                new Category() { Id = 2, Name = "Category2", },
            };

            _productRepositoryMock.Setup(e => e.GetAll()).ReturnsAsync(mockProducts);
            _categoryRepositoryMock.Setup(e => e.GetAll()).ReturnsAsync(mockCategories);
            _categoryRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync((int id) => mockCategories.Find(c => c.Id == id));

            var result = await _productService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var firstProduct = result.First();
            Assert.Equal("Category1", firstProduct.Category.Name);

            var secondProduct = result.Last();
            Assert.Equal(2, secondProduct.Id);
        }

        [Fact]
        public async Task Create_Product_Returns_Product()
        {
            var mockProduct = new Product()
            {
                Id = 1,
                Name = "Test",
                CategoryId = 1,
            };

            var mockCreateProductDto = new CreateProductDto()
            {
                Name = "Test",
                CategoryId = 1,
            };

            var mockCategory = new Category()
            {
                Id = 1,
                Name = "Test",
            };

            _productRepositoryMock.Setup(e => e.Create(It.IsAny<Product>())).ReturnsAsync(mockProduct);
            _unitOfWorkMock.Setup(e => e.CommitAsync()).Returns(Task.CompletedTask);
            _categoryRepositoryMock.Setup(e => e.Get(mockProduct.CategoryId)).ReturnsAsync(mockCategory);

            var result = await _productService.Create(mockCreateProductDto);

            Assert.NotNull(result);
            Assert.Equal(mockProduct.Id, result.Id);
            _productRepositoryMock.Verify(repo => repo.Create(It.IsAny<Product>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Update_Product_Return_Null_If_Invalid_Id()
        {
            var mockUpdateProductDto = new UpdateProductDto()
            {
                Id = -1,
                Name = "Test",
                CategoryId = 1,
            };

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(() => null);

            var result = await _productService.Update(mockUpdateProductDto);

            Assert.Null(result);
        }

        [Fact]
        public async Task Update_Product_Correctly_Valid_Id()
        {
            var mockUpdateProductDto = new UpdateProductDto()
            {
                Id = 1,
                Name = "new",
                Description = "new",
                CategoryId = 2,
                Price = 2.2,
                Quantity = 2,
            };

            var mockProduct = new Product()
            {
                Id = 1,
                Name = "old",
                Description = "old",
                CategoryId = 1,
                Price = 1.1,
                Quantity = 1,
            };

            var mockCategory = new Category()
            {
                Id = 2,
                Name = "test",
            };

            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockProduct);
            _unitOfWorkMock.Setup(e => e.CommitAsync()).Returns(Task.CompletedTask);
            _categoryRepositoryMock.Setup(e => e.Get(mockUpdateProductDto.CategoryId)).ReturnsAsync(mockCategory);

            var result = await _productService.Update(mockUpdateProductDto);

            Assert.NotNull(result);
            Assert.Equal("test", result.Category.Name);
            Assert.Equal(2.2, result.Price);
        }

        [Fact]
        public async Task Invalid_Id_Cannot_Delete()
        {
            _productRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(() => null);

            _productService.Delete(1);

            _productRepositoryMock.Verify(e => e.Delete(It.IsAny<Product>()), Times.Never);
        }
    }
} 