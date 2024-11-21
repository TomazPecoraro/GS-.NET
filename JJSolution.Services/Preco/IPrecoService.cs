using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPrecoService
{
    Task<PrecoDto> GetPrecoByIdAsync(int id);
    Task<IEnumerable<PrecoDto>> GetAllPrecosAsync();
    Task<PrecoDto> CreatePrecoAsync(PrecoDto precoDto);
    Task<PrecoDto> UpdatePrecoAsync(PrecoDto precoDto);
    Task<bool> DeletePrecoAsync(int id);
}
