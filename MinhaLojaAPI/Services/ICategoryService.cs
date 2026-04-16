using MinhaLojaAPI.DTOs;

namespace MinhaLojaAPI.Services
{
	public interface ICategoryService
	{
		public Task<CreateCategoryResponseDTO> Create(CreateCategoryRequestDTO input);
		public Task<IEnumerable<CategoryResponseDTO>> GetAll();
	}
}
