namespace MinhaLojaAPI.Models
{
	internal sealed class Category
	{
		public Guid Id { get; init; } = Guid.NewGuid();
		public string Name { get; init; } = string.Empty;
	}
}