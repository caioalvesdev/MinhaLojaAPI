namespace MinhaLojaAPI.Models
{
	internal sealed class Product
	{
		public Guid Id { get; init; } = Guid.NewGuid();
		public string Name { get; init; } = string.Empty;
		public decimal Price { get; init; }
		public Guid CategoryId { get; init; }
		public Category Category { get; init; } = new();
		public List<Image> Images { get; init; } = [];
	}
}