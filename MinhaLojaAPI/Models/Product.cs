namespace MinhaLojaAPI.Models
{
	public class Product
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }

		public Guid CategoryId { get; set; }
		public Category? Category { get; set; }
		public List<Image> Images { get; set; } = new List<Image>();
	}
}
