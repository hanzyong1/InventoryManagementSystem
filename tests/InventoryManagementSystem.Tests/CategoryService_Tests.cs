using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Dtos.CategoryDto;
using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using Moq;

namespace InventoryManagementSystem.Tests
{
    public class CategoryService_Tests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly CategoryService _categoryService;

        public CategoryService_Tests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(
                _unitOfWorkMock.Object,
                _categoryRepositoryMock.Object
                );
        }

        [Fact]
        public async Task Get_Category_Invalid_Id_Return_Null()
        {
            _categoryRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(() => null);

            var result = await _categoryService.Get(-1);

            Assert.Null(result);
        }

        [Fact]
        public async Task Get_Category_Valid_Id_Return_Category()
        {
            var mockCategory = new Category()
            {
                Id = 1,
                Name = "Test",
            };

            var mockCategoryDto = new GetCategoryDto()
            {
                Id = 1,
                Name = "Test",
            };

            _categoryRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockCategory);

            var result = await _categoryService.Get(1);

            Assert.NotNull(result);
            Assert.Equal(mockCategory.Id, result.Id);
        }

        [Fact]
        public async Task GetAll_Category_Returns_List()
        {
            var mockCategoryList = new List<Category>()
            {
                new Category() { Id = 1, Name = "Test1" },
                new Category() { Id = 2, Name = "Test2" },
            };

            var mockCategoryDtoList = new List<GetCategoryDto>()
            {
                new GetCategoryDto() { Id = 1, Name = "Test1" },
                new GetCategoryDto() { Id = 2, Name = "Test2" },
            };

            _categoryRepositoryMock.Setup(e => e.GetAll()).ReturnsAsync(mockCategoryList);

            var result = await _categoryService.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var firstProduct = result.First();
            Assert.Equal("Test1", firstProduct.Name);

            var secondProduct = result.Last();
            Assert.Equal(2, secondProduct.Id);
        }

        [Fact]
        public async Task Create_Category_Returns_Category()
        {
            var mockCategory = new Category()
            {
                Id = 1,
                Name = "Test",
            };

            var mockCategoryDto = new CreateCategoryDto()
            {
                Name = "Test",
            };

            _categoryRepositoryMock.Setup(e => e.Create(It.IsAny<Category>())).ReturnsAsync(mockCategory);
            _unitOfWorkMock.Setup(e => e.CommitAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.Create(mockCategoryDto);

            Assert.NotNull(result);
            Assert.Equal(mockCategory.Id, result.Id);
            _categoryRepositoryMock.Verify(repo => repo.Create(It.IsAny<Category>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Update_Category_Return_Null_If_Invalid_Id()
        {
            var mockUpdateCategoryDto = new UpdateCategoryDto()
            {
                Id = -1,
                Name = "Test",
            };

            _categoryRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(() => null);

            var result = await _categoryService.Update(mockUpdateCategoryDto);

            Assert.Null(result);
        }

        [Fact]
        public async Task Update_Category_Correctly_Valid_Id()
        {
            var mockUpdateCategoryDto = new UpdateCategoryDto()
            {
                Id = 1,
                Name = "new",
            };

            var mockCategory = new Category()
            {
                Id = 1,
                Name = "old",
            };

            _categoryRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).ReturnsAsync(mockCategory);
            _unitOfWorkMock.Setup(e => e.CommitAsync()).Returns(Task.CompletedTask);

            var result = await _categoryService.Update(mockUpdateCategoryDto);

            Assert.NotNull(result);
            Assert.Equal(mockUpdateCategoryDto.Name, mockCategory.Name);
        }
    }
}
