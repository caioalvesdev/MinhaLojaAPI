using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal interface IProductRepository
	{
		public Task<IEnumerable<Product>> GetAllAsync(Guid? categoryId);
		public Task CreateAsync(Product input);
	}
}
