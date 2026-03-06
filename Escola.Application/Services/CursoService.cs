using System;
using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRespository _cursoRepository;

    public CursoService(ICursoRespository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO)
    {
        var curso = new Domain.Entities.Curso
        {
            Nome = cursoPostDTO.Nome,
            Descricao = cursoPostDTO.Descricao
        };
        var createdCurso = await _cursoRepository.AddAsync(curso);
        return new CursoGetDTO
        {
            Id = createdCurso.Id,
            Nome = createdCurso.Nome,
            Descricao = createdCurso.Descricao
        };
    }

    public async Task<CursoGetDTO> DeleteAsync(int id)
    {
        var deletedCurso = await _cursoRepository.DeleteAsync(id);
        if (deletedCurso == null)
        {
            return null;
        }
        return new CursoGetDTO
        {
            Id = deletedCurso.Id,
            Nome = deletedCurso.Nome,
            Descricao = deletedCurso.Descricao
        };
    }

    public async Task<IEnumerable<CursoGetDTO>> GetAllAsync()
    {
        var cursos = await _cursoRepository.GetAllAsync();
        return cursos.Select(curso => new CursoGetDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        });
    }

    public async Task<CursoGetDTO> GetByIdAsync(int id)
    {
        var curso = await _cursoRepository.GetByIdAsync(id);
        if (curso == null)
        {
            return null;
        }
        return new CursoGetDTO
        {
            Id = curso.Id,
            Nome = curso.Nome,
            Descricao = curso.Descricao
        };
    }

    public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO)
    {
        var curso = new Domain.Entities.Curso
        {
            Id = cursoPutDTO.Id,
            Nome = cursoPutDTO.Nome,
            Descricao = cursoPutDTO.Descricao
        };
        var updatedCurso = await _cursoRepository.UpdateAsync(curso);
        if (updatedCurso == null)
        {
            return null;
        }
        return new CursoGetDTO
        {
            Id = updatedCurso.Id,
            Nome = updatedCurso.Nome,
            Descricao = updatedCurso.Descricao
        };
    }
}
