using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class PrecoRepository : IPrecoRepository
{
    private readonly AppDbContext _context;

    public PrecoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Preco> GetByIdAsync(int id)
    {
        return await _context.Preços
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Preco>> GetAllAsync()
    {
        return await _context.Preços.ToListAsync();
    }

    public async Task<Preco> GetByDateAsync(DateTime data)
    {
        return await _context.Preços
            .FirstOrDefaultAsync(p => p.Data.Date == data.Date); // Comparando apenas a data, ignorando a hora
    }

    public async Task AddAsync(Preco preco)
    {
        await _context.Preços.AddAsync(preco);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Preco preco)
    {
        _context.Preços.Update(preco);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var preco = await GetByIdAsync(id);
        if (preco != null)
        {
            _context.Preços.Remove(preco);
            await _context.SaveChangesAsync();
        }
    }
}
