using InventoryManagementSystem.Data.Repositories;
using InventoryManagementSystem.Data.UnitOfWork;
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
    }
}
