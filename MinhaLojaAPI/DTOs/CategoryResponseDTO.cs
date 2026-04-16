namespace MinhaLojaAPI.DTOs
{
	public sealed record CategoryResponseDTO
	{
		public Guid Id { get; init; }
		public string Name { get; init; } = string.Empty;
	};
}