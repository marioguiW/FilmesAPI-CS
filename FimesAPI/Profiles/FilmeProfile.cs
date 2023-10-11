using AutoMapper;
using FimesAPI.Modules;

namespace FimesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDtos, Filme>();
        CreateMap<UpdateFilmeDtos, Filme>();
        CreateMap<Filme, UpdateFilmeDtos>();
    }
}
