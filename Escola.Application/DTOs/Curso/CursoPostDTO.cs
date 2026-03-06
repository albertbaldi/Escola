using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Curso;

public class CursoPostDTO
{
    [Required(ErrorMessage = "O Nome é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo 50 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A Descrição é obrigatória.")]
    [MaxLength(150, ErrorMessage = "A Descrição deve conter no máximo 150 caracteres.")]
    public string Descricao { get; set; }
}
