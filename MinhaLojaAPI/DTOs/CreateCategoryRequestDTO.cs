using System.ComponentModel.DataAnnotations;

namespace MinhaLojaAPI.DTOs
{
	public sealed record CreateCategoryRequestDTO
	{
		[Required(ErrorMessage = "O campo Name é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo Name deve ter no máximo 100 caracteres.")]
		public string Name { get; set; } = string.Empty;
	}
}
