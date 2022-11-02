using Lojinha3.Domain.Model.Navigation;
using AutoMapper;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;

namespace Lojinha3API.AutomapperConfig
{
    public class LojinhaAccessProfile : Profile
    {
        public LojinhaAccessProfile()
        {
            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id));

            CreateMap<PermissaoMenuUsuario, PermissaoUsuarioDto>()
                .ForMember(pud => pud.Id, p => p.MapFrom(x => x.Id)).ReverseMap();
                

            CreateMap<PermissaoUsuarioDto, PermissaoMenuUsuario>()
                .ForMember(p => p.MenuId, pud => pud.Ignore())
                .ForMember(p => p.Usuario, pud => pud.Ignore()).ReverseMap();

            CreateMap<CategoriaMenuAcessoDto, CategoriaAcesso>()
                .ForMember(d => d.CreatedAt, dto => dto.Ignore()).ReverseMap();
            

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Id, d => d.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
