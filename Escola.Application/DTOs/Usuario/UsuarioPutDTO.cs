using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Usuario;

public class UsuarioPutDTO
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    [MaxLength(250, ErrorMessage = "O nome do usuário não pode exceder 250 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O email do usuário é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
    [MaxLength(100, ErrorMessage = "O email do usuário não pode exceder 100 caracteres.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    [MinLength(8, ErrorMessage = "A senha do usuário deve conter pelo menos 8 caracteres.")]
    [MaxLength(250, ErrorMessage = "A senha do usuário não pode exceder 250 caracteres.")]
    public string Senha { get; set; }
}
