﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.Aparelhos) // Inclui os aparelhos relacionados
            .Include(u => u.Alertas)   // Inclui os alertas relacionados
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
            .Include(u => u.Aparelhos) // Inclui os aparelhos relacionados
            .Include(u => u.Alertas)   // Inclui os alertas relacionados
            .ToListAsync();
    }

    public async Task<Usuario> GetByEmailAsync(string email)
    {
        return await _context.Usuarios
            .Include(u => u.Aparelhos) // Inclui os aparelhos relacionados
            .Include(u => u.Alertas)   // Inclui os alertas relacionados
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await GetByIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
