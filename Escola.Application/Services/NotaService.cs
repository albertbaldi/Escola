using System;
using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class NotaService : INotaService
{
    private readonly INotaRepository _notaRepository;

    public NotaService(INotaRepository notaRepository)
    {
        _notaRepository = notaRepository;
    }

    public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
    {
        var nota = new Domain.Entities.Nota
        {
            MatriculaId = notaPostDTO.MatriculaId,
            ValorNota = notaPostDTO.ValorNota,
            Aprovado = notaPostDTO.ValorNota >= 60, // Exemplo de regra de aprovação
            DataNota = DateTime.UtcNow
        };

        var createdNota = await _notaRepository.AddAsync(nota);

        return new NotaGetDTO
        {
            Id = createdNota.Id,
            MatriculaId = createdNota.MatriculaId,
            ValorNota = createdNota.ValorNota,
            Aprovado = createdNota.Aprovado,
            DataNota = createdNota.DataNota
        };
    }

    public async Task<NotaGetDTO> DeleteAsync(int id)
    {
        var deletedNota = await _notaRepository.DeleteAsync(id);
        if (deletedNota == null)
        {
            return null;
        }
        return new NotaGetDTO
        {
            Id = deletedNota.Id,
            MatriculaId = deletedNota.MatriculaId,
            ValorNota = deletedNota.ValorNota,
            Aprovado = deletedNota.Aprovado,
            DataNota = deletedNota.DataNota
        };
    }

    public async Task<IEnumerable<NotaGetDTO>> GetAllAsync()
    {
        var notas = await _notaRepository.GetAllAsync();
        return notas.Select(n => new NotaGetDTO
        {
            Id = n.Id,
            MatriculaId = n.MatriculaId,
            ValorNota = n.ValorNota,
            Aprovado = n.Aprovado,
            DataNota = n.DataNota
        });
    }

    public async Task<NotaGetDTO> GetByIdAsync(int id)
    {
        var nota = await _notaRepository.GetByIdAsync(id);
        if (nota == null)
        {
            return null;
        }
        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,
            ValorNota = nota.ValorNota,
            Aprovado = nota.Aprovado,
            DataNota = nota.DataNota
        };
    }

    public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
    {
        var existingNota = await _notaRepository.GetByIdAsync(notaPutDTO.Id);
        if (existingNota == null)
        {
            return null;
        }

        existingNota.ValorNota = notaPutDTO.ValorNota;
        existingNota.Aprovado = notaPutDTO.ValorNota >= 60; // Exemplo de regra de aprovação

        var updatedNota = await _notaRepository.UpdateAsync(existingNota);
        if (updatedNota == null)
        {
            return null;
        }
        return new NotaGetDTO
        {
            Id = updatedNota.Id,
            MatriculaId = updatedNota.MatriculaId,
            ValorNota = updatedNota.ValorNota,
            Aprovado = updatedNota.Aprovado,
            DataNota = updatedNota.DataNota
        };
    }
}
