namespace MinhaLojaAPI.DTOs
{
	public sealed record UserDTO
	{
		public Guid Id { get; init; }
		public string Username { get; init; } = string.Empty;
		public string Email { get; init; } = string.Empty;
	}
}