using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class AlertaRepository : IAlertaRepository
{
    private readonly OracleDbContext _context;

    public AlertaRepository(OracleDbContext context)
    {
        _context = context;
    }

    public async Task<Alerta> GetByIdAsync(int id)
    {
        return await _context.Alertas
            .Include(a => a.Usuario)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Alerta>> GetAllAsync()
    {
        return await _context.Alertas
            .Include(a => a.Usuario)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alerta>> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Alertas
            .Where(a => a.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task AddAsync(Alerta alerta)
    {
        await _context.Alertas.AddAsync(alerta);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Alerta alerta)
    {
        _context.Alertas.Update(alerta);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var alerta = await GetByIdAsync(id);
        if (alerta != null)
        {
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }
    }
}
