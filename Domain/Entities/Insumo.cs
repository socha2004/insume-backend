namespace insume_backend.Domain.Entities
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
        public decimal? EstoqueMinimo { get; set; }
        public DateOnly? DataValidade { get; set; }
        public string? Marca { get; set; }
        public string? Observacao { get; set; }

        public int IdCategoria { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
