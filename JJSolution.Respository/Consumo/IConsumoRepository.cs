using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConsumoRepository
{
    Task<Consumo> GetByIdAsync(int id); // Obter um consumo por ID
    Task<IEnumerable<Consumo>> GetAllAsync(); // Obter todos os consumos
    Task<IEnumerable<Consumo>> GetByAparelhoIdAsync(int aparelhoId); // Obter consumos por ID do aparelho
    Task<IEnumerable<Consumo>> GetByDateRangeAsync(DateTime startDate, DateTime endDate); // Obter consumos por intervalo de datas
    Task<Consumo> AddAsync(Consumo consumo); // Adicionar um novo consumo
    Task<Consumo> UpdateAsync(Consumo consumo); // Atualizar um consumo existente
    Task DeleteAsync(int id); // Deletar um consumo por ID
}

