using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioRepository
{
    Task<Usuario> GetByIdAsync(int id); // Obter um usuário por ID
    Task<IEnumerable<Usuario>> GetAllAsync(); // Obter todos os usuários
    Task<Usuario> GetByEmailAsync(string email); // Obter usuário por email
    Task<Usuario> AddAsync(Usuario usuario); // Adicionar um novo usuário
    Task<Usuario> UpdateAsync(Usuario usuario); // Atualizar um usuário existente
    Task DeleteAsync(int id); // Deletar um usuário por ID
}
