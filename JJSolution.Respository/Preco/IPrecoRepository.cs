using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPrecoRepository
{
    Task<Preco> GetByIdAsync(int id); // Obter um preço por ID
    Task<IEnumerable<Preco>> GetAllAsync(); // Obter todos os preços
    Task<Preco> GetByDateAsync(DateTime data); // Obter o preço por data
    Task<Preco> AddAsync(Preco preco); // Adicionar um novo preço
    Task<Preco> UpdateAsync(Preco preco); // Atualizar um preço existente
    Task DeleteAsync(int id); // Deletar um preço por ID
}
