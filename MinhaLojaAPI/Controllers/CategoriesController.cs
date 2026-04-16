using Microsoft.AspNetCore.Mvc;
using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Services;

namespace MinhaLojaAPI.Controllers
{
	public sealed class CategoriesController(ICategoryService categoryService) : MainController
	{
		private readonly ICategoryService _categoryService = categoryService;

		[HttpPost]
		[ProducesResponseType(typeof(CreateCategoryResponseDTO), StatusCodes.Status201Created)]
		public async Task<ActionResult<CreateCategoryResponseDTO>> Create(CreateCategoryRequestDTO categoria)
		{
			var response = await _categoryService.Create(categoria);

			return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response);
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<CategoryResponseDTO>), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAll()
		{
			var response = await _categoryService.GetAll();

			return Ok(response);
		}
	}
}
