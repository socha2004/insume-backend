using insume_backend.Application.DTOs.Categoria;

namespace insume_backend.Application.Interfaces
{
    public interface ICategoriaService
    {
       Task<IEnumerable<CategoriaResponseDto>> GetAllAsync();
        Task<CategoriaResponseDto> GetByIdAsync(int id);
        Task<CategoriaResponseDto> CreateAsync(CategoriaRequestDto categoriaRequestDto);
        Task<CategoriaResponseDto> UpdateAsync(int id, CategoriaRequestDto categoriaRequestDto);
        Task<bool> DeleteAsync(int id);
    }
}
