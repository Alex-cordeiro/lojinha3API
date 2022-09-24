using AutoMapper;
using Lojinha3.Business.Interfaces;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaMenuAcessoController : ControllerBase
    {
        private readonly ICategoriaMenuAcessoBussiness _categoriaMenuAcesso;
        private readonly IMapper _mapper;

        public CategoriaMenuAcessoController(ICategoriaMenuAcessoBussiness IcategoriaMenuAcesso, IMapper mapper)
        {
            _categoriaMenuAcesso = IcategoriaMenuAcesso;
            _mapper = mapper;
        }


        // GET: CategoriaMenuAcessoController/Details/5
        [HttpGet("RetornaCategoriasMenuAcesso")]
        public IActionResult RetornaCategoriaMenuAcessos()
        {
            var retornoCategorias = _categoriaMenuAcesso.FindAll();
            var teste = _mapper.Map<CategoriaMenuAcessoDto>(retornoCategorias);


            return Ok();
        }

        //// GET: CategoriaMenuAcessoController/Details/5
        //[HttpGet("RetornaCategoriasMenuAcessoUsuario")]
        //public IActionResult RetornaCategoriaMenuAcessos(UsuarioDto usuarioDto)
        //{
        //    var usuarioParaRetorno = _mapper.Map<Usuario>(usuarioDto);

        //    //return Ok(_categoriaMenuAcesso.FindbyUserPermission(usuarioParaRetorno);
        //}

        [HttpPost("NovaCategoriaMenuAcesso")]
        public IActionResult NovaCategoriaMenuAcesso([FromBody] CategoriaMenuAcessoDto categoriaMenuAcesso)
        {
            var novaCategoriaMenuAcesso = _mapper.Map<CategoriaMenuAcesso>(categoriaMenuAcesso);
            var desenvolvedoraCriada = _categoriaMenuAcesso.Create(novaCategoriaMenuAcesso);

            if (desenvolvedoraCriada != null)
                return Ok(desenvolvedoraCriada);
            return BadRequest("Não foi possível realizar a inserção do registro!");
        }

        [HttpPut("AlterarCategoriaMenuAcesso")]
        public IActionResult AlterarCategoriaMenuAcesso([FromBody] CategoriaMenuAcessoDto desenvolvedora)
        {
            var desenvolvedoraParaEdicao = _mapper.Map<CategoriaMenuAcesso>(desenvolvedora);
            var desenvolvedoraAlterada = _categoriaMenuAcesso.Update(desenvolvedoraParaEdicao);

            if (desenvolvedoraAlterada != null)
                return Ok(desenvolvedoraAlterada);
            return BadRequest("Não foi possível alterar o registro!");


        }

        [HttpDelete("DeletarCategoriaMenuAcesso/{Id}")]
        public IActionResult DeletaCategoriaMenuAcesso(int Id)
        {
            var retornoDelete = _categoriaMenuAcesso.Delete(Id);

            if (retornoDelete)
                return Ok("Registro Apagado Com Sucesso!");
            return BadRequest("Não foi possível realizar a operação!");
        }
    }
}
