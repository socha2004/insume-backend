namespace insume_backend.Application.DTOs.Categoria
{
    public class CategoriaRequestDto
    {
        public string Titulo { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
    }
}
