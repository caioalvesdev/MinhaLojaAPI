using System.ComponentModel.DataAnnotations;

namespace MinhaLojaAPI.DTOs
{
	public sealed record LoginRequestDTO
	{
		[Required(ErrorMessage = "O campo Email é obrigatório.")]
		[EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
		public string Email { get; init; } = string.Empty;

		[Required(ErrorMessage = "O campo Password é obrigatório.")]
		[MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres.")]
		public string Password { get; init; } = string.Empty;
	}
}