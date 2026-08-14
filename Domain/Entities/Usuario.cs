namespace insume_backend.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;

        public ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();
        public ICollection<Categoria> Categorias { get; set; }
    }
}
