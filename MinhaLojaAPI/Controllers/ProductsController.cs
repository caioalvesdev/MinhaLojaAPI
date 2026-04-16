using Microsoft.AspNetCore.Mvc;
using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Services;

namespace MinhaLojaAPI.Controllers
{
	public sealed class ProductsController(IProductService productsService) : MainController
	{
		private readonly IProductService _productsService = productsService;

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAll([FromQuery] Guid? categoryId)
		{
			var response = await _productsService.GetAll(categoryId);

			return Ok(response);
		}

		[HttpPost]
		[ProducesResponseType(typeof(CreateProductResponseDTO), StatusCodes.Status201Created)]
		public async Task<ActionResult<CreateProductResponseDTO>> Create([FromBody] CreateProductRequestDTO request)
		{
			var response = await _productsService.Create(request);

			return CreatedAtAction(nameof(GetAll), new { id = response.Id }, response);
		}
	}
}
