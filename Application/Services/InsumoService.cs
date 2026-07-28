using insume_backend.Application.DTOs;
using insume_backend.Application.DTOs.Insumo;
using insume_backend.Application.Interfaces;
using insume_backend.Domain.Entities;
using insume_backend.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace insume_backend.Application.Services
{
    public class InsumoService : IInsumoService
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsumoService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<InsumoResponseDto>> GetAllAsync()
        {
            var usuarioId = GetUsuarioLogadoId();
            return await _context.Insumos
                .Where(i => i.IdUsuario == usuarioId)
                .Include(i => i.Categoria)
                .Include(i => i.Usuario)
                .Select(i => MapToResponseDto(i))
                .ToListAsync();
        }

        public async Task<InsumoResponseDto?> GetByIdAsync(int id)
        {
            var usuarioId = GetUsuarioLogadoId();
            var insumo = await _context.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(i => i.Id == id && i.IdUsuario == usuarioId);

            return insumo == null ? null : MapToResponseDto(insumo);
        }

        public async Task<InsumoResponseDto> CreateAsync(InsumoRequestDto dto)
        {
            var usuarioId = GetUsuarioLogadoId();

            var categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.Id == dto.IdCategoria && c.UsuarioId == usuarioId );

            if (!categoriaExiste)
                throw new InvalidOperationException("Categoria inválida ou não pertence ao usuário.");

            var insumo = new Insumo
            {
                Nome = dto.Nome,
                Quantidade = dto.Quantidade,
                UnidadeMedida = dto.UnidadeMedida,
                EstoqueMinimo = dto.EstoqueMinimo,
                DataValidade = dto.DataValidade,
                Marca = dto.Marca,
                Observacao = dto.Observacao,
                IdCategoria = dto.IdCategoria,
                IdUsuario = usuarioId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Insumos.Add(insumo);
            await _context.SaveChangesAsync();

            // Recarrega com os relacionamentos pra montar a resposta completa
            await _context.Entry(insumo).Reference(i => i.Categoria).LoadAsync();
            await _context.Entry(insumo).Reference(i => i.Usuario).LoadAsync();

            return MapToResponseDto(insumo);
        }

        public async Task<InsumoResponseDto?> UpdateAsync(int id, InsumoRequestDto dto)
        {
            var usuarioId = GetUsuarioLogadoId();

            var insumo = await _context.Insumos
                .Include(i => i.Categoria)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(i => i.Id == id && i.IdUsuario == usuarioId);

            if (insumo == null)
                return null;

            if (insumo.IdUsuario != GetUsuarioLogadoId())
                throw new UnauthorizedAccessException("Você não tem permissão para editar este insumo.");

            var categoriaExiste = await _context.Categorias
                .AnyAsync(c => c.Id == dto.IdCategoria && c.UsuarioId == usuarioId);

            if (!categoriaExiste)
                throw new InvalidOperationException("Categoria informada não existe.");

            insumo.Nome = dto.Nome;
            insumo.Quantidade = dto.Quantidade;
            insumo.UnidadeMedida = dto.UnidadeMedida;
            insumo.EstoqueMinimo = dto.EstoqueMinimo;
            insumo.DataValidade = dto.DataValidade;
            insumo.Marca = dto.Marca;
            insumo.Observacao = dto.Observacao;
            insumo.IdCategoria = dto.IdCategoria;
            insumo.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Recarrega a Categoria, caso ela tenha mudado
            await _context.Entry(insumo).Reference(i => i.Categoria).LoadAsync();

            return MapToResponseDto(insumo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuarioId = GetUsuarioLogadoId();
            var insumo = await _context.Insumos.FirstOrDefaultAsync(i => i.Id == id && i.IdUsuario == usuarioId);

            if (insumo == null)
                return false;

            if (insumo.IdUsuario != GetUsuarioLogadoId())
                throw new UnauthorizedAccessException("Você não tem permissão para excluir este insumo.");

            _context.Insumos.Remove(insumo);
            await _context.SaveChangesAsync();

            return true;
        }

        // ---- Métodos auxiliares privados ----

        private int GetUsuarioLogadoId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? _httpContextAccessor.HttpContext?.User
                .FindFirst("sub")?.Value;

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Usuário não autenticado.");

            return int.Parse(userIdClaim);
        }

        private static InsumoResponseDto MapToResponseDto(Insumo i)
        {
            return new InsumoResponseDto
            {
                Id = i.Id,
                Nome = i.Nome,
                Quantidade = i.Quantidade,
                UnidadeMedida = i.UnidadeMedida,
                EstoqueMinimo = i.EstoqueMinimo,
                DataValidade = i.DataValidade,
                Marca = i.Marca,
                Observacao = i.Observacao,
                Categoria = i.Categoria.Titulo,
                CriadoPor = i.Usuario.Nome,
                CreatedAt = i.CreatedAt,
                UpdatedAt = i.UpdatedAt
            };
        }
    }
}