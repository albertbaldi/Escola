using System;

namespace Escola.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    /// <summary>
    /// O PasswordHash é o resultado da aplicação de uma função de hash à senha do usuário, combinada com o PasswordSalt. 
    /// Ele é armazenado no banco de dados para autenticar o usuário durante o login, sem expor a senha original.
    /// </summary>
    public byte[] PasswordHash { get; set; }
    /// <summary>
    /// O PasswordSalt é um valor aleatório que é adicionado à senha antes de ser hashada, para aumentar a segurança contra ataques de força bruta e rainbow tables.
    /// </summary>
    public byte[] PasswordSalt { get; set; }
    public string Perfil { get; set; }
    public bool Excluido { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
}
