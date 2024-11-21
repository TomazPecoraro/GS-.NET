using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<UsuarioDto> GetUsuarioByIdAsync(int id); // Obter um usuário por ID
    Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync(); // Obter todos os usuários
    Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuarioDto); // Adicionar um novo usuário
    Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioDto usuarioDto); // Atualizar um usuário existente
    Task<bool> DeleteUsuarioAsync(int id); // Deletar um usuário por ID
}
