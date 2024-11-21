using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AnaliseController : ControllerBase
{
    private readonly IAnaliseService _analiseService;

    public AnaliseController(IAnaliseService analiseService)
    {
        _analiseService = analiseService;
    }

    // GET: api/Analise/ConsumoTotal
    [HttpGet("ConsumoTotal")]
    public async Task<IActionResult> GetConsumoTotal([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
    {
        var resultado = await _analiseService.CalcularConsumoTotalAsync(dataInicial, dataFinal);
        if (resultado == null)
        {
            return NotFound("Nenhum consumo encontrado para o período especificado.");
        }
        return Ok(resultado);
    }

    // GET:
