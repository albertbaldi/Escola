using System;
using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;

    public MatriculaService(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

    public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
    {
        var matricula = new Domain.Entities.Matricula
        {
            UsuarioId = matriculaPostDTO.UsuarioId,
            TurmaId = matriculaPostDTO.TurmaId,
            DataMatricula = DateTime.UtcNow,
            DataExpiracao = matriculaPostDTO.DataExpiracao,
            Ativa = true
        };

        var createdMatricula = await _matriculaRepository.AddAsync(matricula);

        return new MatriculaGetDTO
        {
            Id = createdMatricula.Id,
            UsuarioId = createdMatricula.UsuarioId,
            TurmaId = createdMatricula.TurmaId,
            DataMatricula = createdMatricula.DataMatricula,
            DataExpiracao = createdMatricula.DataExpiracao,
            Ativa = createdMatricula.Ativa
        };
    }

    public async Task<MatriculaGetDTO> DeleteAsync(int id)
    {
        var deletedMatricula = await _matriculaRepository.DeleteAsync(id);
        if (deletedMatricula == null)
        {
            return null;
        }
        return new MatriculaGetDTO
        {
            Id = deletedMatricula.Id,
            UsuarioId = deletedMatricula.UsuarioId,
            TurmaId = deletedMatricula.TurmaId,
            DataMatricula = deletedMatricula.DataMatricula,
            DataExpiracao = deletedMatricula.DataExpiracao,
            Ativa = deletedMatricula.Ativa
        };
    }

    public async Task<IEnumerable<MatriculaGetDetailDTO>> GetAllAsync()
    {
        var matriculas = await _matriculaRepository.GetAllAsync();
        return matriculas.Select(m => new MatriculaGetDetailDTO
        {
            Id = m.Id,
            Usuario = new UsuarioGetDTO
            {
                Id = m.Usuario.Id,
                Nome = m.Usuario.Nome,
                Email = m.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = m.Turma.Id,
                Nome = m.Turma.Nome,
                Descricao = m.Turma.Descricao
            },
            DataMatricula = m.DataMatricula,
            DataExpiracao = m.DataExpiracao,
            Ativa = m.Ativa
        });
    }

    public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
    {
        var matricula = await _matriculaRepository.GetByIdAsync(id);
        if (matricula == null)
        {
            return null;
        }
        return new MatriculaGetDetailDTO
        {
            Id = matricula.Id,
            Usuario = new UsuarioGetDTO
            {
                Id = matricula.Usuario.Id,
                Nome = matricula.Usuario.Nome,
                Email = matricula.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = matricula.Turma.Id,
                Nome = matricula.Turma.Nome,
                Descricao = matricula.Turma.Descricao
            },
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa
        };
    }

    public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
    {
        var matricula = new Domain.Entities.Matricula
        {
            Id = matriculaPutDTO.Id,
            TurmaId = matriculaPutDTO.TurmaId,
            DataExpiracao = matriculaPutDTO.DataExpiracao,
        };

        var updatedMatricula = await _matriculaRepository.UpdateAsync(matricula);
        if (updatedMatricula == null)
        {
            return null;
        }
        return new MatriculaGetDTO
        {
            Id = updatedMatricula.Id,
            UsuarioId = updatedMatricula.UsuarioId,
            TurmaId = updatedMatricula.TurmaId,
            DataMatricula = updatedMatricula.DataMatricula,
            DataExpiracao = updatedMatricula.DataExpiracao,
            Ativa = updatedMatricula.Ativa
        };
    }
}
