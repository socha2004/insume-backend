using insume_backend.Domain.Entities;

namespace insume_backend.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int idUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();
    }
}