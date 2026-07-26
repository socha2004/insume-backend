using insume_backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using insume_backend.Application.DTOs.Categoria;

namespace insume_backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponseDto>> GetById(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null)
                return NotFound($"Categoria com id {id} não encontrada.");
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponseDto>> Create(CategoriaRequestDto dto)
        {
            var categoria = await _categoriaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaResponseDto>> Update(int id, CategoriaRequestDto dto)
        {
            var categoria = await _categoriaService.UpdateAsync(id, dto);
            if (categoria == null)
                return NotFound($"Categoria com id {id} não encontrada.");
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoriaService.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Categoria com id {id} não encontrada.");
            return NoContent();
        }

    }
}
