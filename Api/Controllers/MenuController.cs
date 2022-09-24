using AutoMapper;
using Business.Interfaces;
using Lojinha3.Business.Interfaces;
using Lojinha3.Domain.Model.Dtos;
using Lojinha3.Domain.Model.Games;
using Lojinha3.Domain.Model.Navigation;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuBusiness _menuBusiness;
        private readonly IMapper _mapper;

        public MenuController(IMenuBusiness menuBusiness, IMapper mapper)
        {
            _menuBusiness = menuBusiness;
            _mapper = mapper;
        }

        [HttpGet("RetornaMenus")]
        public IActionResult RetornaMenus()
        {
            return Ok(_menuBusiness.FindAll());
        }

        [HttpPost("RetornaMenusPorAcesso")]
        public IActionResult RetornaMenusPorAcesso([FromBody] UsuarioDto usuarioDto)
        {
            return Ok(_menuBusiness.FindAll());
        }


        [HttpPost("NovoMenu")]
        public IActionResult NovoMenu([FromBody] MenuDto menuDto)
        {
            var novoMenu = _mapper.Map<Menu>(menuDto);
            var menuCriado = _menuBusiness.Create(novoMenu);

            if (menuCriado != null)
                return Ok(menuCriado);
            return BadRequest("Não foi possível realizar a inserção do registro!");
        }

        [HttpPut("AlterarMenu")]
        public IActionResult AlterarMenu([FromBody] MenuDto menuDto)
        {
            var menuParaedicao = _mapper.Map<Menu>(menuDto);
            var menualterado = _menuBusiness.Update(menuParaedicao);

            if (menualterado != null)
                return Ok(menualterado);
            return BadRequest("Não foi possível alterar o registro!");


        }

        [HttpDelete("DeletarMenu/{Id}")]
        public IActionResult DeletaDesenvolvedora(int Id)
        {
            var retornoDelete = _menuBusiness.Delete(Id);

            if (retornoDelete)
                return Ok("Registro Apagado Com Sucesso!");
            return BadRequest("Não foi possível realizar a operação!");
        }

    }
}


