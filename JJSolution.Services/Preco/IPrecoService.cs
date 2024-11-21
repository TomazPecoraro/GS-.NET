using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPrecoService
{
    Task<PrecoDto> GetPrecoByIdAsync(int id);
    Task<IEnumerable<PrecoDto>> GetAllPrecosAsync();
    Task CreatePrecoAsync(PrecoDto precoDto);
    Task UpdatePrecoAsync(PrecoDto precoDto);
    Task DeletePrecoAsync(int id);
}
