using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Alerta, AlertaDto>().ReverseMap();
        CreateMap<Aparelho, AparelhoDto>().ReverseMap();
        CreateMap<Consumo, ConsumoDto>().ReverseMap();
        CreateMap<Preco, PrecoDto>().ReverseMap();
        CreateMap<Usuario, UsuarioDto>().ReverseMap();

    }
}
