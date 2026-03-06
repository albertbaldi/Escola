using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Turma;

public class TurmaPostDTO
{
    [Required(ErrorMessage = "O nome da turma é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome da turma não pode exceder 50 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição da turma é obrigatória.")]
    [MaxLength(150, ErrorMessage = "A descrição da turma não pode exceder 150 caracteres.")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O identificador do curso é obrigatório.")]
    public int CursoId { get; set; }
}
