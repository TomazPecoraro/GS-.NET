using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAparelhoService
{
    Task<AparelhoDto> GetAparelhoByIdAsync(int id);
    Task<IEnumerable<AparelhoDto>> GetAparelhosByUsuarioIdAsync(int usuarioId);
    Task CreateAparelhoAsync(AparelhoDto aparelhoDto);
    Task UpdateAparelhoAsync(AparelhoDto aparelhoDto);
    Task DeleteAparelhoAsync(int id);
}
