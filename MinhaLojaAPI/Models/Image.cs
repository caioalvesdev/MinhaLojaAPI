namespace MinhaLojaAPI.Models
{
	public class Image
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Url { get; set; } = string.Empty;
		public Guid ProductId { get; set; }
	}
}
