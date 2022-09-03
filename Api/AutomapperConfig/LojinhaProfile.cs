using AutoMapper;
using Lojinha3API.Dtos;
using Lojinha3.Domain.Model;

namespace Lojinha3API.AutomapperConfig
{
    public class LojinhaProfile : Profile
    {
        public LojinhaProfile()
        {
            CreateMap<Desenvolvedora, DesenvolvedoraDto>()
                .ForMember(dto => dto.IdDesenvolvedora, d => d.MapFrom(x => x.Id));
            CreateMap<Desenvolvedora, DesenvolvedoraDto>()
                .ForMember(dto => dto.IdDesenvolvedora, d => d.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
