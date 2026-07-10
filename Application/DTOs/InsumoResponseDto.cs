namespace insume_backend.Application.DTOs
{
    public class InsumoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public decimal? EstoqueMinimo { get; set; }
        public DateOnly? DataValidade { get; set; }
        public string? Marca { get; set; }
        public string? Observacao { get; set; }

        public string Categoria { get; set; } = string.Empty;
        public string CriadoPor { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
