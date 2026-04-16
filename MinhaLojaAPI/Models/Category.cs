namespace MinhaLojaAPI.Models
{
	internal sealed class Category
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;
	}
}