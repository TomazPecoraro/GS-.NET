using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JJSolution.DataBase;

public class AparelhoRepository : IAparelhoRepository
{
    private readonly OracleDbContext _context;

    public AparelhoRepository(OracleDbContext context)
    {
        _context = context;
    }

    public async Task<Aparelho> GetByIdAsync(int id)
    {
        return await _context.Aparelhos
            .Include(a => a.Usuario)
            .Include(a => a.Consumos)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Aparelho>> GetAllAsync()
    {
        return await _context.Aparelhos
            .Include(a => a.Usuario)
            .Include(a => a.Consumos)
            .ToListAsync();
    }

    public async Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId)
    {
        return await _context.Aparelhos
            .Where(a => a.UsuarioId == usuarioId)
            .Include(a => a.Consumos)
            .ToListAsync();
    }

    public async Task<Aparelho> AddAsync(Aparelho aparelho)
    {
        await _context.Aparelhos.AddAsync(aparelho);
        await _context.SaveChangesAsync();
        return aparelho;
    }

    public async Task<Aparelho> UpdateAsync(Aparelho aparelho)
    {
        _context.Aparelhos.Update(aparelho);
        await _context.SaveChangesAsync();
        return aparelho;
    }

    public async Task DeleteAsync(int id)
    {
        var aparelho = await GetByIdAsync(id);
        if (aparelho != null)
        {
            _context.Aparelhos.Remove(aparelho);
            await _context.SaveChangesAsync();
        }
    }
}
