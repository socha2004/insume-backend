namespace insume_backend.Application.DTOs.Insumo
{
    public class InsumoRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public decimal? EstoqueMinimo { get; set; }
        public DateOnly? DataValidade { get; set; }
        public string? Marca { get; set; }
        public string? Observacao { get; set; }
        public int IdCategoria { get; set; }
    }
}
