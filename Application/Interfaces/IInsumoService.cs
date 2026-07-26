using insume_backend.Application.DTOs.Insumo;

namespace insume_backend.Application.Interfaces
{
    public interface IInsumoService
    {
        Task<IEnumerable<InsumoResponseDto>> GetAllAsync();
        Task<InsumoResponseDto?> GetByIdAsync(int id);
        Task<InsumoResponseDto> CreateAsync(InsumoRequestDto dto);
        Task<InsumoResponseDto?> UpdateAsync(int id, InsumoRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
