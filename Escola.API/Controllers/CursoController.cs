using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurso(CursoPostDTO cursoPostDTO)
        {
            var createdCurso = await _cursoService.AddAsync(cursoPostDTO);
            if (createdCurso == null)
            {
                return BadRequest("Não foi possível criar o curso.");
            }

            return Ok(createdCurso);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCurso(CursoPutDTO cursoPutDTO)
        {
            var updatedCurso = await _cursoService.UpdateAsync(cursoPutDTO);
            if (updatedCurso == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar o curso.");
            }

            return Ok(updatedCurso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var deletedCurso = await _cursoService.DeleteAsync(id);
            if (deletedCurso == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o curso.");
            }

            return Ok("Curso excluído com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCursoById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }

            return Ok(curso);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCursos()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }
    }
}
