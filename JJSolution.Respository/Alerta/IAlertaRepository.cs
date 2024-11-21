using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAlertaRepository
{
    Task<Alerta> GetByIdAsync(int id); // Obter um alerta por ID
    Task<IEnumerable<Alerta>> GetAllAsync(); // Obter todos os alertas
    Task<IEnumerable<Alerta>> GetByUsuarioIdAsync(int usuarioId); // Obter alertas por ID do usuário
    Task<Alerta> AddAsync(Alerta alerta); // Adicionar um novo alerta
    Task<Alerta> UpdateAsync(Alerta alerta); // Atualizar um alerta existente
    Task DeleteAsync(int id); // Deletar um alerta por ID
}
