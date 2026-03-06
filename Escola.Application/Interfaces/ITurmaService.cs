using System;
using Escola.Application.DTOs.Turma;

namespace Escola.Application.Interfaces;

public interface ITurmaService
{
    Task<TurmaGetDetailDTO> GetByIdAsync(int id);
    Task<IEnumerable<TurmaGetDetailDTO>> GetAllAsync();
    Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
    Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
    Task<TurmaGetDTO> DeleteAsync(int id);
}
