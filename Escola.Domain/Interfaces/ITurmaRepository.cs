using System;
using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface ITurmaRepository
{
    Task<Turma> GetByIdAsync(int id);
    Task<IEnumerable<Turma>> GetAllAsync();
    Task<Turma> AddAsync(Turma turma);
    Task<Turma> UpdateAsync(Turma turma);
    Task<Turma> DeleteAsync(int id);
}
