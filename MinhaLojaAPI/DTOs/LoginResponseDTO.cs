namespace MinhaLojaAPI.DTOs
{
	public sealed record LoginResponseDTO
	{
		public string AccessToken { get; init; } = string.Empty;
		public DateTime ExpiresAt { get; init; }
		public UserDTO User { get; init; } = new();
	}
}