using insume_backend.Application.DTOs;
using insume_backend.Application.DTOs.Insumo;
using insume_backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace insume_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InsumoController : ControllerBase
    {
        private readonly IInsumoService _insumoService;

        public InsumoController(IInsumoService insumoService)
        {
            _insumoService = insumoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsumoResponseDto>>> GetAll()
        {
            var insumos = await _insumoService.GetAllAsync();
            return Ok(insumos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsumoResponseDto>> GetById(int id)
        {
            var insumo = await _insumoService.GetByIdAsync(id);

            if (insumo == null)
                return NotFound($"Insumo com id {id} não encontrado.");

            return Ok(insumo);
        }

        [HttpPost]
        public async Task<ActionResult<InsumoResponseDto>> Create(InsumoRequestDto dto)
        {
            try
            {
                var insumo = await _insumoService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = insumo.Id }, insumo);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InsumoResponseDto>> Update(int id, InsumoRequestDto dto)
        {
            try
            {
                var insumo = await _insumoService.UpdateAsync(id, dto);

                if (insumo == null)
                    return NotFound($"Insumo com id {id} não encontrado.");

                return Ok(insumo);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(); // 403 - autenticado, mas sem permissão para essa ação
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var sucesso = await _insumoService.DeleteAsync(id);

                if (!sucesso)
                    return NotFound($"Insumo com id {id} não encontrado.");

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
        }
    }
}