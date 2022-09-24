using Lojinha3.Domain.Model.Navigation;
using AutoMapper;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Domain.Model.Access;

namespace Lojinha3API.AutomapperConfig
{
    public class LojinhaAccessProfile : Profile
    {
        public LojinhaAccessProfile()
        {
            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id));
            CreateMap<PermissaoMenuUsuario, PermissaoMenuUsuarioDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id)).ReverseMap();
            //CreateMap<CategoriaMenuAcessoDto, CategoriaMenuAcesso>()
            //    .ForMember(d => d., dto => dto.Ignore());
           
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id));
        }
    }
}
