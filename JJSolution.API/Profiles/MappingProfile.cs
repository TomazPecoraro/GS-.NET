using AutoMapper;
using JJSolution.Models.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Alerta, AlertaDTO>().ReverseMap();
        CreateMap<Aparelho, AparelhoDTO>().ReverseMap();
        CreateMap<Consumo, ConsumoDTO>().ReverseMap();
        CreateMap<Preco, PrecoDTO>().ReverseMap();
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();

    }
}
