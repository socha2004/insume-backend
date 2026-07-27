using insume_backend.Application.DTOs.Categoria;
using insume_backend.Application.Interfaces;
using insume_backend.Domain.Entities;
using insume_backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        private int GetUsuarioIdLogado()
        {
            var usuarioIdClaim = _httpContextAccessor.HttpContext!.User
                .FindFirst(ClaimTypes.NameIdentifier)!.Value;

            return int.Parse(usuarioIdClaim);
        }

        public async Task<IEnumerable<CategoriaResponseDto>> GetAllAsync()
        {
            var usuarioId = GetUsuarioIdLogado();
            var categorias = await _context.Categorias
                .Where(c => c.idUsuario == usuarioId)
                .ToListAsync();

            return categorias.Select(c => new CategoriaResponseDto
            {
                Id = c.Id,
                Titulo = c.Titulo
            });
        }

        public async Task<CategoriaResponseDto?> GetByIdAsync(int id)
        {
            var usuarioId = GetUsuarioIdLogado();

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(c => c.Id == id && c.Id == usuarioId);

            if (categoria == null) return null;

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Titulo = categoria.Titulo
            };
        }

        public async Task<CategoriaResponseDto> CreateAsync(CategoriaRequestDto dto)
        {
            var usuarioId = GetUsuarioIdLogado();
            var categoria = new Categoria
            {
                Titulo = dto.Titulo,
                idUsuario = usuarioId
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
            var usuarioId = GetUsuarioIdLogado();

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id && c.Id == usuarioId);

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
            var usuarioId = GetUsuarioIdLogado();

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id && c.Id == usuarioId);

            if (categoria == null) return false;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
