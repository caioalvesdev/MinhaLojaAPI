namespace MinhaLojaAPI.DTOs
{
	public sealed record ProductResponseDTO
	{
		public Guid Id { get; init; }
		public string Name { get; init; } = string.Empty;
		public decimal Price { get; init; }
		public Guid CategoryId { get; init; }
		public List<CreateImageDTO> Images { get; init; } = [];
	}
}
