namespace MinhaLojaAPI.DTOs
{
	public sealed record AuthResponseDTO
	{
		public string AccessToken { get; init; } = string.Empty;
		public DateTime ExpiresAt { get; init; }
		public UserDTO User { get; init; } = new();
	}
}