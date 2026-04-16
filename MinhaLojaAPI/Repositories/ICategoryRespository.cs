using MinhaLojaAPI.Models;

namespace MinhaLojaAPI.Repositories
{
	internal interface ICategoryRespository
	{
		public Task<IEnumerable<Category>> GetAllAsync();
		public Task CreateAsync(Category input);
	}
}
