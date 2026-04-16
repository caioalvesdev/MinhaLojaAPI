using MinhaLojaAPI.DTOs;
using MinhaLojaAPI.Models;
using MinhaLojaAPI.Repositories;

namespace MinhaLojaAPI.Services
{
	internal sealed class CategoryService(ICategoryRespository categoryRepository) : ICategoryService
	{
		private readonly ICategoryRespository _categoryRepository = categoryRepository;

		public async Task<CreateCategoryResponseDTO> Create(CreateCategoryRequestDTO input)
		{
			var category = new Category
			{
				Name = input.Name
			};

			await _categoryRepository.CreateAsync(category);

			return new CreateCategoryResponseDTO
			{
				Id = category.Id,
				Name = category.Name
			};
		}

		public async Task<IEnumerable<CategoryResponseDTO>> GetAll()
		{
			var categories = await _categoryRepository.GetAllAsync();

			return categories.Select(x => new CategoryResponseDTO
			{
				Id = x.Id,
				Name = x.Name
			});
		}
	}
}
