using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioDto> GetByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null)
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email
        }).ToList();
    }

    public async Task<UsuarioDto> GetByEmailAsync(string email)
    {
        var usuario = await _usuarioRepository.GetByEmailAsync(email);
        if (usuario == null)
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    public async Task AddAsync(UsuarioDto usuarioDto)
    {
        if (usuarioDto == null)
            throw new ArgumentNullException(nameof(usuarioDto));

        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Senha = "senha_gerada" // Lógica de senha (pode ser criada ou passada como parâmetro)
        };

        // Adicione validações ou outras lógicas de negócios, se necessário
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task UpdateAsync(UsuarioDto usuarioDto)
    {
        if (usuarioDto == null)
            throw new ArgumentNullException(nameof(usuarioDto));

        var usuario = await _usuarioRepository.GetByIdAsync(usuarioD
