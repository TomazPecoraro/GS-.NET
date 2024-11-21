using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<UsuarioDto> GetByIdAsync(int id); // Obter um usuário por ID
    Task<IEnumerable<UsuarioDto>> GetAllAsync(); // Obter todos os usuários
    Task<UsuarioDto> GetByEmailAsync(string email); // Obter usuário por email
    Task AddAsync(UsuarioDto usuarioDto); // Adicionar um novo usuário
    Task UpdateAsync(UsuarioDto usuarioDto); // Atualizar um usuário existente
    Task DeleteAsync(int id); // Deletar um usuário por ID
}
