using InventoryManagementSystem.Dtos.CategoryDto;
using InventoryManagementSystem.Dtos.ProductDto;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
            {
                return BadRequest();
            }

            var product = await _categoryService.Create(createCategoryDto);

            return Ok(product);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (id != updateCategoryDto.Id)
            {
                return BadRequest();
            }

            var product = await _categoryService.Update(updateCategoryDto);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
