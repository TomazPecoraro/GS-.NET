using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConsumoService
{
    Task<IEnumerable<ConsumoDto>> GetAllConsumosAsync();
    Task<ConsumoDto> GetConsumoByIdAsync(int id);
    Task<ConsumoDto> CreateConsumoAsync(ConsumoDto consumoDto);
    Task<ConsumoDto> UpdateConsumoAsync(int id, ConsumoDto consumoDto);
    Task<bool> DeleteConsumoAsync(int id);
}

