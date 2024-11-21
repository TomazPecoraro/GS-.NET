using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConsumoService
{
    Task<ConsumoDto> GetConsumoByIdAsync(int id);
    Task<IEnumerable<ConsumoDto>> GetConsumosByAparelhoIdAsync(int aparelhoId);
    Task<IEnumerable<ConsumoDto>> GetConsumosByPrecoIdAsync(int precoId);
    Task<IEnumerable<Consumo>> GetConsumosByUsuarioIdAsync(int usuarioId);
    Task CreateConsumoAsync(ConsumoDto consumoDto);
    Task UpdateConsumoAsync(ConsumoDto consumoDto);
    Task DeleteConsumoAsync(int id);
}

}
