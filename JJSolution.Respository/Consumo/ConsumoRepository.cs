using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ConsumoRepository : IConsumoRepository
{
    private readonly AppDbContext _context;

    public ConsumoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Consumo> GetByIdAsync(int id)
    {
        return await _context.Consumos
            .Include(c => c.Aparelho)
            .Include(c => c.Preco)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Consumo>> GetAllAsync()
    {
        return await _context.Consumos
            .Include(c => c.Aparelho)
            .Include(c => c.Preco)
            .ToListAsync();
    }

    public async Task<IEnumerable<Consumo>> GetByAparelhoIdAsync(int aparelhoId)
    {
        return await _context.Consumos
            .Where(c => c.AparelhoId == aparelhoId)
            .Include(c => c.Preco)
            .ToListAsync();
    }

    public async Task<IEnumerable<Consumo>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Consumos
            .Where(c => c.Data >= startDate && c.Data <= endDate)
            .Include(c => c.Aparelho)
            .Include(c => c.Preco)
            .ToListAsync();
    }

    public async Task AddAsync(Consumo consumo)
    {
        await _context.Consumos.AddAsync(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consumo consumo)
    {
        _context.Consumos.Update(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consumo = await GetByIdAsync(id);
        if (consumo != null)
        {
            _context.Consumos.Remove(consumo);
            await _context.SaveChangesAsync();
        }
    }
}

