using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAparelhoService
{
    Task<IEnumerable<AparelhoDto>> GetAllAparelhosAsync();
    Task<AparelhoDto> GetAparelhoByIdAsync(int id);
    Task<AparelhoDto> CreateAparelhoAsync(AparelhoDto aparelhoDto);
    Task<AparelhoDto> UpdateAparelhoAsync(int id, AparelhoDto aparelhoDto);
    Task<bool> DeleteAparelhoAsync(int id);
}
