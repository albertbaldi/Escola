using Escola.Application.DTOs.Matricula;
using Escola.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatricula(MatriculaPostDTO matriculaPostDTO)
        {
            var createdMatricula = await _matriculaService.AddAsync(matriculaPostDTO);
            if (createdMatricula == null)
            {
                return BadRequest("Não foi possível criar a matrícula.");
            }

            return Ok(createdMatricula);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatricula(MatriculaPutDTO matriculaPutDTO)
        {
            var updatedMatricula = await _matriculaService.UpdateAsync(matriculaPutDTO);
            if (updatedMatricula == null)
            {
                return BadRequest("Ocorreu um erro ao atualizar a matrícula.");
            }

            return Ok(updatedMatricula);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            var deletedMatricula = await _matriculaService.DeleteAsync(id);
            if (deletedMatricula == null)
            {
                return BadRequest("Ocorreu um erro ao excluir a matrícula.");
            }

            return Ok("Matrícula excluída com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatriculaById(int id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);
            if (matricula == null)
            {
                return NotFound("Matrícula não encontrada.");
            }

            return Ok(matricula);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatriculas()
        {
            var matriculas = await _matriculaService.GetAllAsync();
            return Ok(matriculas);
        }
    }
}
