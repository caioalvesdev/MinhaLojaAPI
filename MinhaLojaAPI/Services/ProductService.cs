using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Models;
using MinhaLojaAPI.Repositories;

namespace MinhaLojaAPI.Services
{
	internal sealed class ProductService(IProductRepository productRepository) : IProductService
	{
		private readonly IProductRepository _productRepository = productRepository;

		public async Task<CreateProductResponseDTO> Create(CreateProductRequestDTO input)
		{
			var product = new Product
			{
				Name = input.Name,
				Price = input.Price,
				CategoryId = input.CategoryId,
				Images = input.Images.Select(i => new Image { Id = i.Id, Url = i.Url, ProductId = i.ProductId }).ToList()
			};

			await _productRepository.CreateAsync(product);

			return new CreateProductResponseDTO
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				CategoryId = product.Category.Id,
				Images = product.Images.Select(i => new CreateImageDTO
				{
					Id = i.Id,
					Url = i.Url,
					ProductId = i.ProductId
				}).ToList()
			};
		}

		public async Task<IEnumerable<ProductResponseDTO>> GetAll(Guid? categoryId)
		{
			var products = await _productRepository.GetAllAsync(categoryId);

			return products.Select(p => new ProductResponseDTO
			{
				Id = p.Id,
				Name = p.Name,
				Price = p.Price,
				CategoryId = p.CategoryId,
				Images = p.Images.Select(i => new CreateImageDTO
				{
					Id = i.Id,
					Url = i.Url,
					ProductId = i.ProductId
				}).ToList()
			});
		}
	}
}
