using insume_backend.Application.DTOs.Categoria;
using insume_backend.Application.Interfaces;
using insume_backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using insume_backend.Domain.Entities;

namespace insume_backend.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriaService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<CategoriaResponseDto>> GetAllAsync()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias.Select(c => new CategoriaResponseDto
            {
                Id = c.Id,
                Titulo = c.Titulo
            });
        }

        public async Task<CategoriaResponseDto?> GetByIdAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return null;
            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Titulo = categoria.Titulo
            };
        }

        public async Task<CategoriaResponseDto> CreateAsync(CategoriaRequestDto dto)
        {
            var categoria = new Categoria
            {
                Titulo = dto.Titulo
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Titulo = categoria.Titulo
            };
        }

        public async Task<CategoriaResponseDto?> UpdateAsync(int id, CategoriaRequestDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return null;

            categoria.Titulo = dto.Titulo;
            await _context.SaveChangesAsync();

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Titulo = categoria.Titulo
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
