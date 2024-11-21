using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAparelhoRepository
{
    Task<Aparelho> GetByIdAsync(int id); // Obter um aparelho por ID
    Task<IEnumerable<Aparelho>> GetAllAsync(); // Obter todos os aparelhos
    Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId); // Obter aparelhos por ID do usuário
    Task<Aparelho> AddAsync(Aparelho aparelho); // Adicionar um novo aparelho
    Task<Aparelho> UpdateAsync(Aparelho aparelho); // Atualizar um aparelho existente
    Task DeleteAsync(int id); // Deletar um aparelho por ID
}
