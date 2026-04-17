namespace MinhaLojaAPI.Models
{
	internal sealed class User
	{
		public Guid Id { get; init; }
		public string Username { get; init; } = string.Empty;
		public string Email { get; init; } = string.Empty;
		public string PasswordHash { get; init; } = string.Empty;
		public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
	}
}