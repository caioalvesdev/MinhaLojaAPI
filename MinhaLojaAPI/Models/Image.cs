namespace MinhaLojaAPI.Models
{
	internal sealed class Image
	{
		public Guid Id { get; init; } = Guid.NewGuid();
		public string Url { get; init; } = string.Empty;
		public Guid ProductId { get; init; }
	}
}