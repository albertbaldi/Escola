using System;
using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface ICursoRespository
{
    Task<Curso> GetByIdAsync(int id);
    Task<IEnumerable<Curso>> GetAllAsync();
    Task<Curso> AddAsync(Curso curso);
    Task<Curso> UpdateAsync(Curso curso);
    Task<Curso> DeleteAsync(int id);
}
