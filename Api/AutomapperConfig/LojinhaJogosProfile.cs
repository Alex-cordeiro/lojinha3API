using AutoMapper;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Domain.Model.Games;

namespace Lojinha3API.AutomapperConfig
{
    public class LojinhaJogosProfile : Profile
    {
        public LojinhaJogosProfile()
        {
            CreateMap<Desenvolvedora, DesenvolvedoraDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id));
            CreateMap<Desenvolvedora, DesenvolvedoraDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
