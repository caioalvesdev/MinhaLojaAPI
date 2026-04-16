using System.ComponentModel.DataAnnotations;

namespace MinhaLojaAPI.DTOs
{
	public sealed record CreateCategory
	{
		[Required(ErrorMessage = "O {0} da categoria é obrigatório.")]
		public Guid Id { get; set; }
	}

	public sealed record CreateImageDTO
	{
		[Required(ErrorMessage = "O {0} da imagem é obrigatório.")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "A {0} da imagem é obrigatória.")]
		public string Url { get; set; } = string.Empty;

		[Required(ErrorMessage = "O {0} da imagem é obrigatório.")]
		public Guid ProductId { get; set; }
	}

	public sealed record CreateProductRequestDTO
	{
		[Required(ErrorMessage = "O {0} do produto é obrigatório.")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "O {0} do produto é obrigatório.")]
		[Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que {1}.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "O {0} da categoria é obrigatório.")]
		public Guid CategoryId { get; set; }

		[Required(ErrorMessage = "As {0} do produto são obrigatórias.")]
		public List<CreateImageDTO> Images { get; set; } = [];
	}
}
