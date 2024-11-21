using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JJSolution.DataBase;

public class PrecoRepository : IPrecoRepository
{
    private readonly OracleDbContext _context;

    public PrecoRepository(OracleDbContext context)
    {
        _context = context;
    }

    public async Task<Preco> GetByIdAsync(int id)
    {
        return await _context.Precos
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Preco>> GetAllAsync()
    {
        return await _context.Precos.ToListAsync();
    }

    public async Task<Preco> GetByDateAsync(DateTime data)
    {
        return await _context.Precos
            .FirstOrDefaultAsync(p => p.Data.Date == data.Date); // Comparando apenas a data, ignorando a hora
    }

    public async Task<Preco> AddAsync(Preco preco)
    {
        await _context.Precos.AddAsync(preco);
        await _context.SaveChangesAsync();
        return preco;
    }

    public async Task<Preco> UpdateAsync(Preco preco)
    {
        _context.Precos.Update(preco);
        await _context.SaveChangesAsync();
        return preco;
    }

    public async Task DeleteAsync(int id)
    {
        var preco = await GetByIdAsync(id);
        if (preco != null)
        {
            _context.Precos.Remove(preco);
            await _context.SaveChangesAsync();
        }
    }
}
