using MinhaLojaAPI.DTOs;

namespace MinhaLojaAPI.Services
{
	public interface IProductService
	{
		public Task<IEnumerable<ProductResponseDTO>> GetAll(Guid? categoryId);
		public Task<CreateProductResponseDTO> Create(CreateProductRequestDTO input);
	}
}
